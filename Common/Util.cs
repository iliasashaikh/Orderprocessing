using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Reflection;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using FluentNHibernate.Mapping;

namespace Common
{
  public class Util
  {
    const string CONTEXT_KEY = "contextkey";

    public static string GetContextId()
    {
      if (OperationContext.Current != null)
      {
        ContextMessageProperty messageProperty = OperationContext.Current.IncomingMessageProperties[ContextMessageProperty.Name] as ContextMessageProperty;
        if (messageProperty != null && messageProperty.Context.ContainsKey(CONTEXT_KEY))
        {
          string contextId = messageProperty.Context[CONTEXT_KEY];
          if (!String.IsNullOrEmpty(contextId))
            return contextId;
        }
      }

      return Thread.CurrentContext.ContextID.ToString();
    }

    public static void SetContextId(IClientChannel innerChannel, string contextId)
    {
      IContextManager cntxManager = innerChannel.GetProperty<IContextManager>();
      IDictionary<string, string> context = cntxManager.GetContext();
      context.Add(CONTEXT_KEY, contextId);
      cntxManager.SetContext(context);
    }

    public static void AssignContextId(IClientChannel innerChannel)
    {
      string contextId = Guid.NewGuid().ToString();
      Common.Util.SetContextId(innerChannel, contextId);
    }

    public static void LogMessageToEventLog(string message)
    {
      string source = Assembly.GetExecutingAssembly().FullName;
      if (!EventLog.SourceExists(source))
        EventLog.CreateEventSource(source,"Application");
      EventLog.WriteEntry(source, message);
    }

    public static Expression<Func<IDictionary, object>> CreateExpression(string dictionaryName, string fieldName, Type fieldType)
    {
      if (String.IsNullOrEmpty(dictionaryName))
        throw new ArgumentException("dictionaryName is null or empty.", "dictionaryName");
      if (String.IsNullOrEmpty(fieldName))
        throw new ArgumentException("fieldName is null or empty.", "fieldName");
      if (fieldType == null)
        throw new ArgumentNullException("fieldType", "fieldType is null.");

      Expression paramName = Expression.Constant(fieldName, Type.GetType("System.String"));
      ParameterExpression dictName = Expression.Parameter(Type.GetType("System.Collections.IDictionary"), dictionaryName);
      Expression methodCall = Expression.Call(dictName, Type.GetType("System.Collections.IDictionary").GetMethod("get_Item"), new Expression[] { paramName });
      Expression unaryConvert = Expression.MakeUnary(ExpressionType.Convert, methodCall, fieldType);
      Expression convertAgain = Expression.MakeUnary(ExpressionType.Convert, unaryConvert, Type.GetType("System.Object"));
      Expression<Func<IDictionary, object>> convert = Expression.Lambda<Func<IDictionary, object>>(convertAgain, new ParameterExpression[] { dictName });

      return convert;
    }

    public static void MapDynamicColumns(DynamicComponentPart<System.Collections.IDictionary> m)
    {
      string customColFile = @"C:\MyDev\OrderProcessing\OrderProcessingDomain\Domain\CustomColumns.xml";
      if (!File.Exists(customColFile)) 
        return;

      FieldInfo fi = m.GetType().GetField("entity", BindingFlags.Instance | BindingFlags.NonPublic);
      
      object o = fi.GetValue(m);
      string tableName = o.ToString();

      XElement xe = XElement.Load(customColFile);
      var classes = xe.Descendants("class").Where(x=>x.Attribute("table").Value == tableName);

      foreach (XElement xeClass in classes)
      {
        foreach (XElement xeColumns in xeClass.Elements("columns"))
        {
          foreach (XElement xeColumn in xeColumns.Elements("column"))
          {
            string colName = xeColumn.Attribute("name").Value;
            string typeName = xeColumn.Attribute("type").Value;

            m.Map(CreateExpression("x", colName, Type.GetType(typeName)));
          }
        }
      }
 
    }

  }
}
