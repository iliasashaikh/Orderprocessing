using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace OrderProcessingDomain
{
  [DataContract]
  public class EntityBase
  {
    [DataMember]
    public virtual Hashtable CustomFields { get; set; }

    string _dynamicColumnString = "";
    [DataMember]
    public virtual string CustomColumnString
    {
      get
      {
        StringBuilder builder = new StringBuilder();
        
        if (CustomFields == null)
          return "";

        foreach (DictionaryEntry entry in CustomFields)
        {
          builder.AppendFormat(@"{0}:{1};", entry.Key, entry.Value);
        }
        _dynamicColumnString = builder.ToString();
        return _dynamicColumnString;
      }
      set
      {
        _dynamicColumnString = value;
      }
    }
  }
}
