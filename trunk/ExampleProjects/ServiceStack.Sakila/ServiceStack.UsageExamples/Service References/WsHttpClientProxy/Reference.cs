﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceStack.UsageExamples.WsHttpClientProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfIntId", Namespace="http://schemas.servicestack.net/types/", ItemName="Id")]
    [System.SerializableAttribute()]
    public class ArrayOfIntId : System.Collections.Generic.List<int> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="Properties", Namespace="http://schemas.servicestack.net/types/", ItemName="Property")]
    [System.SerializableAttribute()]
    public class Properties : System.Collections.Generic.List<ServiceStack.UsageExamples.WsHttpClientProxy.Property> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Property", Namespace="http://schemas.servicestack.net/types/")]
    [System.SerializableAttribute()]
    public partial class Property : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customer", Namespace="http://schemas.servicestack.net/types/")]
    [System.SerializableAttribute()]
    public partial class Customer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceStack.UsageExamples.WsHttpClientProxy.Address AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StoreIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceStack.UsageExamples.WsHttpClientProxy.Address Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int StoreId {
            get {
                return this.StoreIdField;
            }
            set {
                if ((this.StoreIdField.Equals(value) != true)) {
                    this.StoreIdField = value;
                    this.RaisePropertyChanged("StoreId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Address", Namespace="http://schemas.servicestack.net/types/")]
    [System.SerializableAttribute()]
    public partial class Address : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceStack.UsageExamples.WsHttpClientProxy.City CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Line1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Line2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PostCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TownField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceStack.UsageExamples.WsHttpClientProxy.City City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Line1 {
            get {
                return this.Line1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Line1Field, value) != true)) {
                    this.Line1Field = value;
                    this.RaisePropertyChanged("Line1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Line2 {
            get {
                return this.Line2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Line2Field, value) != true)) {
                    this.Line2Field = value;
                    this.RaisePropertyChanged("Line2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PostCode {
            get {
                return this.PostCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.PostCodeField, value) != true)) {
                    this.PostCodeField = value;
                    this.RaisePropertyChanged("PostCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Town {
            get {
                return this.TownField;
            }
            set {
                if ((object.ReferenceEquals(this.TownField, value) != true)) {
                    this.TownField = value;
                    this.RaisePropertyChanged("Town");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="City", Namespace="http://schemas.servicestack.net/types/")]
    [System.SerializableAttribute()]
    public partial class City : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceStack.UsageExamples.WsHttpClientProxy.Country CountryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceStack.UsageExamples.WsHttpClientProxy.Country Country {
            get {
                return this.CountryField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryField, value) != true)) {
                    this.CountryField = value;
                    this.RaisePropertyChanged("Country");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Country", Namespace="http://schemas.servicestack.net/types/")]
    [System.SerializableAttribute()]
    public partial class Country : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseStatus", Namespace="http://schemas.servicestack.net/types/")]
    [System.SerializableAttribute()]
    public partial class ResponseStatus : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceStack.UsageExamples.WsHttpClientProxy.ResponseError[] ErrorsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorCodeField, value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceStack.UsageExamples.WsHttpClientProxy.ResponseError[] Errors {
            get {
                return this.ErrorsField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorsField, value) != true)) {
                    this.ErrorsField = value;
                    this.RaisePropertyChanged("Errors");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseError", Namespace="http://schemas.servicestack.net/types/")]
    [System.SerializableAttribute()]
    public partial class ResponseError : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FieldNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorCodeField, value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FieldName {
            get {
                return this.FieldNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FieldNameField, value) != true)) {
                    this.FieldNameField = value;
                    this.RaisePropertyChanged("FieldName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://services.servicestack.net/", ConfigurationName="WsHttpClientProxy.ISyncReply")]
    public interface ISyncReply {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://schemas.servicestack.net/types/) of message GetCustomersRequest does not match the default value (http://services.servicestack.net/)
        [System.ServiceModel.OperationContractAttribute(Action="http://services.servicestack.net/GetCustomers", ReplyAction="*")]
        ServiceStack.UsageExamples.WsHttpClientProxy.GetCustomersResponse GetCustomers(ServiceStack.UsageExamples.WsHttpClientProxy.GetCustomersRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetCustomers", WrapperNamespace="http://schemas.servicestack.net/types/", IsWrapped=true)]
    public partial class GetCustomersRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.servicestack.net/types/", Order=0)]
        public ServiceStack.UsageExamples.WsHttpClientProxy.ArrayOfIntId CustomerIds;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.servicestack.net/types/", Order=1)]
        public ServiceStack.UsageExamples.WsHttpClientProxy.Properties Properties;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.servicestack.net/types/", Order=2)]
        public int Version;
        
        public GetCustomersRequest() {
        }
        
        public GetCustomersRequest(ServiceStack.UsageExamples.WsHttpClientProxy.ArrayOfIntId CustomerIds, ServiceStack.UsageExamples.WsHttpClientProxy.Properties Properties, int Version) {
            this.CustomerIds = CustomerIds;
            this.Properties = Properties;
            this.Version = Version;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetCustomersResponse", WrapperNamespace="http://schemas.servicestack.net/types/", IsWrapped=true)]
    public partial class GetCustomersResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.servicestack.net/types/", Order=0)]
        public ServiceStack.UsageExamples.WsHttpClientProxy.Customer[] Customers;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.servicestack.net/types/", Order=1)]
        public ServiceStack.UsageExamples.WsHttpClientProxy.Properties Properties;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.servicestack.net/types/", Order=2)]
        public ServiceStack.UsageExamples.WsHttpClientProxy.ResponseStatus ResponseStatus;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.servicestack.net/types/", Order=3)]
        public int Version;
        
        public GetCustomersResponse() {
        }
        
        public GetCustomersResponse(ServiceStack.UsageExamples.WsHttpClientProxy.Customer[] Customers, ServiceStack.UsageExamples.WsHttpClientProxy.Properties Properties, ServiceStack.UsageExamples.WsHttpClientProxy.ResponseStatus ResponseStatus, int Version) {
            this.Customers = Customers;
            this.Properties = Properties;
            this.ResponseStatus = ResponseStatus;
            this.Version = Version;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ISyncReplyChannel : ServiceStack.UsageExamples.WsHttpClientProxy.ISyncReply, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SyncReplyClient : System.ServiceModel.ClientBase<ServiceStack.UsageExamples.WsHttpClientProxy.ISyncReply>, ServiceStack.UsageExamples.WsHttpClientProxy.ISyncReply {
        
        public SyncReplyClient() {
        }
        
        public SyncReplyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SyncReplyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SyncReplyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SyncReplyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceStack.UsageExamples.WsHttpClientProxy.GetCustomersResponse ServiceStack.UsageExamples.WsHttpClientProxy.ISyncReply.GetCustomers(ServiceStack.UsageExamples.WsHttpClientProxy.GetCustomersRequest request) {
            return base.Channel.GetCustomers(request);
        }
        
        public ServiceStack.UsageExamples.WsHttpClientProxy.Customer[] GetCustomers(ServiceStack.UsageExamples.WsHttpClientProxy.ArrayOfIntId CustomerIds, ref ServiceStack.UsageExamples.WsHttpClientProxy.Properties Properties, ref int Version, out ServiceStack.UsageExamples.WsHttpClientProxy.ResponseStatus ResponseStatus) {
            ServiceStack.UsageExamples.WsHttpClientProxy.GetCustomersRequest inValue = new ServiceStack.UsageExamples.WsHttpClientProxy.GetCustomersRequest();
            inValue.CustomerIds = CustomerIds;
            inValue.Properties = Properties;
            inValue.Version = Version;
            ServiceStack.UsageExamples.WsHttpClientProxy.GetCustomersResponse retVal = ((ServiceStack.UsageExamples.WsHttpClientProxy.ISyncReply)(this)).GetCustomers(inValue);
            Properties = retVal.Properties;
            ResponseStatus = retVal.ResponseStatus;
            Version = retVal.Version;
            return retVal.Customers;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://services.servicestack.net/", ConfigurationName="WsHttpClientProxy.IOneWay")]
    public interface IOneWay {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://schemas.servicestack.net/types/) of message StoreCustomer does not match the default value (http://services.servicestack.net/)
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://services.servicestack.net/StoreCustomer")]
        void StoreCustomer(ServiceStack.UsageExamples.WsHttpClientProxy.StoreCustomer request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="StoreCustomer", WrapperNamespace="http://schemas.servicestack.net/types/", IsWrapped=true)]
    public partial class StoreCustomer {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.servicestack.net/types/", Order=0)]
        public ServiceStack.UsageExamples.WsHttpClientProxy.Customer Customer;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.servicestack.net/types/", Order=1)]
        public ServiceStack.UsageExamples.WsHttpClientProxy.Properties Properties;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.servicestack.net/types/", Order=2)]
        public int Version;
        
        public StoreCustomer() {
        }
        
        public StoreCustomer(ServiceStack.UsageExamples.WsHttpClientProxy.Customer Customer, ServiceStack.UsageExamples.WsHttpClientProxy.Properties Properties, int Version) {
            this.Customer = Customer;
            this.Properties = Properties;
            this.Version = Version;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IOneWayChannel : ServiceStack.UsageExamples.WsHttpClientProxy.IOneWay, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class OneWayClient : System.ServiceModel.ClientBase<ServiceStack.UsageExamples.WsHttpClientProxy.IOneWay>, ServiceStack.UsageExamples.WsHttpClientProxy.IOneWay {
        
        public OneWayClient() {
        }
        
        public OneWayClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OneWayClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OneWayClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OneWayClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void ServiceStack.UsageExamples.WsHttpClientProxy.IOneWay.StoreCustomer(ServiceStack.UsageExamples.WsHttpClientProxy.StoreCustomer request) {
            base.Channel.StoreCustomer(request);
        }
        
        public void StoreCustomer(ServiceStack.UsageExamples.WsHttpClientProxy.Customer Customer, ServiceStack.UsageExamples.WsHttpClientProxy.Properties Properties, int Version) {
            ServiceStack.UsageExamples.WsHttpClientProxy.StoreCustomer inValue = new ServiceStack.UsageExamples.WsHttpClientProxy.StoreCustomer();
            inValue.Customer = Customer;
            inValue.Properties = Properties;
            inValue.Version = Version;
            ((ServiceStack.UsageExamples.WsHttpClientProxy.IOneWay)(this)).StoreCustomer(inValue);
        }
    }
}