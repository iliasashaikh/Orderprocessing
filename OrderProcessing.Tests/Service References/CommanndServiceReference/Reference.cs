﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderProcessing.Tests.CommanndServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CommanndServiceReference.ICommandService")]
    public interface ICommandService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/ExecuteCommand", ReplyAction="http://tempuri.org/ICommandService/ExecuteCommandResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.UpdateOrderCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.AddOrderCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.RemoveCustomerCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.RemoveOrderCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Order))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.EntityBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Customer))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Employee))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
        object ExecuteCommand(object command);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ICommandService/ExecuteCommand", ReplyAction="http://tempuri.org/ICommandService/ExecuteCommandResponse")]
        System.IAsyncResult BeginExecuteCommand(object command, System.AsyncCallback callback, object asyncState);
        
        object EndExecuteCommand(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Undo", ReplyAction="http://tempuri.org/ICommandService/UndoResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.UpdateOrderCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.AddOrderCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.RemoveCustomerCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.RemoveOrderCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Order))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.EntityBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Customer))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Employee))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
        object Undo();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ICommandService/Undo", ReplyAction="http://tempuri.org/ICommandService/UndoResponse")]
        System.IAsyncResult BeginUndo(System.AsyncCallback callback, object asyncState);
        
        object EndUndo(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/UndoCommand", ReplyAction="http://tempuri.org/ICommandService/UndoCommandResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.UpdateOrderCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.AddOrderCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.RemoveCustomerCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Command.RemoveOrderCommand))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Order))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.EntityBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Customer))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(OrderProcessingDomain.Employee))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
        object UndoCommand(object command);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ICommandService/UndoCommand", ReplyAction="http://tempuri.org/ICommandService/UndoCommandResponse")]
        System.IAsyncResult BeginUndoCommand(object command, System.AsyncCallback callback, object asyncState);
        
        object EndUndoCommand(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICommandServiceChannel : OrderProcessing.Tests.CommanndServiceReference.ICommandService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class ExecuteCommandCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ExecuteCommandCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public object Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((object)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class UndoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UndoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public object Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((object)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class UndoCommandCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UndoCommandCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public object Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((object)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class CommandServiceClient : System.ServiceModel.ClientBase<OrderProcessing.Tests.CommanndServiceReference.ICommandService>, OrderProcessing.Tests.CommanndServiceReference.ICommandService {
        
        private BeginOperationDelegate onBeginExecuteCommandDelegate;
        
        private EndOperationDelegate onEndExecuteCommandDelegate;
        
        private System.Threading.SendOrPostCallback onExecuteCommandCompletedDelegate;
        
        private BeginOperationDelegate onBeginUndoDelegate;
        
        private EndOperationDelegate onEndUndoDelegate;
        
        private System.Threading.SendOrPostCallback onUndoCompletedDelegate;
        
        private BeginOperationDelegate onBeginUndoCommandDelegate;
        
        private EndOperationDelegate onEndUndoCommandDelegate;
        
        private System.Threading.SendOrPostCallback onUndoCommandCompletedDelegate;
        
        public CommandServiceClient() {
        }
        
        public CommandServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CommandServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommandServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommandServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<ExecuteCommandCompletedEventArgs> ExecuteCommandCompleted;
        
        public event System.EventHandler<UndoCompletedEventArgs> UndoCompleted;
        
        public event System.EventHandler<UndoCommandCompletedEventArgs> UndoCommandCompleted;
        
        public object ExecuteCommand(object command) {
            return base.Channel.ExecuteCommand(command);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginExecuteCommand(object command, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginExecuteCommand(command, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public object EndExecuteCommand(System.IAsyncResult result) {
            return base.Channel.EndExecuteCommand(result);
        }
        
        private System.IAsyncResult OnBeginExecuteCommand(object[] inValues, System.AsyncCallback callback, object asyncState) {
            object command = ((object)(inValues[0]));
            return this.BeginExecuteCommand(command, callback, asyncState);
        }
        
        private object[] OnEndExecuteCommand(System.IAsyncResult result) {
            object retVal = this.EndExecuteCommand(result);
            return new object[] {
                    retVal};
        }
        
        private void OnExecuteCommandCompleted(object state) {
            if ((this.ExecuteCommandCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ExecuteCommandCompleted(this, new ExecuteCommandCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ExecuteCommandAsync(object command) {
            this.ExecuteCommandAsync(command, null);
        }
        
        public void ExecuteCommandAsync(object command, object userState) {
            if ((this.onBeginExecuteCommandDelegate == null)) {
                this.onBeginExecuteCommandDelegate = new BeginOperationDelegate(this.OnBeginExecuteCommand);
            }
            if ((this.onEndExecuteCommandDelegate == null)) {
                this.onEndExecuteCommandDelegate = new EndOperationDelegate(this.OnEndExecuteCommand);
            }
            if ((this.onExecuteCommandCompletedDelegate == null)) {
                this.onExecuteCommandCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnExecuteCommandCompleted);
            }
            base.InvokeAsync(this.onBeginExecuteCommandDelegate, new object[] {
                        command}, this.onEndExecuteCommandDelegate, this.onExecuteCommandCompletedDelegate, userState);
        }
        
        public object Undo() {
            return base.Channel.Undo();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUndo(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUndo(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public object EndUndo(System.IAsyncResult result) {
            return base.Channel.EndUndo(result);
        }
        
        private System.IAsyncResult OnBeginUndo(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginUndo(callback, asyncState);
        }
        
        private object[] OnEndUndo(System.IAsyncResult result) {
            object retVal = this.EndUndo(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUndoCompleted(object state) {
            if ((this.UndoCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UndoCompleted(this, new UndoCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UndoAsync() {
            this.UndoAsync(null);
        }
        
        public void UndoAsync(object userState) {
            if ((this.onBeginUndoDelegate == null)) {
                this.onBeginUndoDelegate = new BeginOperationDelegate(this.OnBeginUndo);
            }
            if ((this.onEndUndoDelegate == null)) {
                this.onEndUndoDelegate = new EndOperationDelegate(this.OnEndUndo);
            }
            if ((this.onUndoCompletedDelegate == null)) {
                this.onUndoCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUndoCompleted);
            }
            base.InvokeAsync(this.onBeginUndoDelegate, null, this.onEndUndoDelegate, this.onUndoCompletedDelegate, userState);
        }
        
        public object UndoCommand(object command) {
            return base.Channel.UndoCommand(command);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginUndoCommand(object command, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUndoCommand(command, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public object EndUndoCommand(System.IAsyncResult result) {
            return base.Channel.EndUndoCommand(result);
        }
        
        private System.IAsyncResult OnBeginUndoCommand(object[] inValues, System.AsyncCallback callback, object asyncState) {
            object command = ((object)(inValues[0]));
            return this.BeginUndoCommand(command, callback, asyncState);
        }
        
        private object[] OnEndUndoCommand(System.IAsyncResult result) {
            object retVal = this.EndUndoCommand(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUndoCommandCompleted(object state) {
            if ((this.UndoCommandCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UndoCommandCompleted(this, new UndoCommandCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UndoCommandAsync(object command) {
            this.UndoCommandAsync(command, null);
        }
        
        public void UndoCommandAsync(object command, object userState) {
            if ((this.onBeginUndoCommandDelegate == null)) {
                this.onBeginUndoCommandDelegate = new BeginOperationDelegate(this.OnBeginUndoCommand);
            }
            if ((this.onEndUndoCommandDelegate == null)) {
                this.onEndUndoCommandDelegate = new EndOperationDelegate(this.OnEndUndoCommand);
            }
            if ((this.onUndoCommandCompletedDelegate == null)) {
                this.onUndoCommandCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUndoCommandCompleted);
            }
            base.InvokeAsync(this.onBeginUndoCommandDelegate, new object[] {
                        command}, this.onEndUndoCommandDelegate, this.onUndoCommandCompletedDelegate, userState);
        }
    }
}
