﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.34209 版自动生成。
// 
#pragma warning disable 1591

namespace Sys.psService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PostCodeSoap", Namespace="http://www.wufish.com/WebService/")]
    public partial class PostCode : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetAllProvinceNameOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCityNameOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetTownNameOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCityCodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCityNameByPostCodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCityNameByTelCodeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public PostCode() {
            this.Url = global::Sys.Properties.Settings.Default.Sys_psService_PostCode;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetAllProvinceNameCompletedEventHandler GetAllProvinceNameCompleted;
        
        /// <remarks/>
        public event GetCityNameCompletedEventHandler GetCityNameCompleted;
        
        /// <remarks/>
        public event GetTownNameCompletedEventHandler GetTownNameCompleted;
        
        /// <remarks/>
        public event GetCityCodeCompletedEventHandler GetCityCodeCompleted;
        
        /// <remarks/>
        public event GetCityNameByPostCodeCompletedEventHandler GetCityNameByPostCodeCompleted;
        
        /// <remarks/>
        public event GetCityNameByTelCodeCompletedEventHandler GetCityNameByTelCodeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.wufish.com/WebService/GetAllProvinceName", RequestNamespace="http://www.wufish.com/WebService/", ResponseNamespace="http://www.wufish.com/WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetAllProvinceName() {
            object[] results = this.Invoke("GetAllProvinceName", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllProvinceNameAsync() {
            this.GetAllProvinceNameAsync(null);
        }
        
        /// <remarks/>
        public void GetAllProvinceNameAsync(object userState) {
            if ((this.GetAllProvinceNameOperationCompleted == null)) {
                this.GetAllProvinceNameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllProvinceNameOperationCompleted);
            }
            this.InvokeAsync("GetAllProvinceName", new object[0], this.GetAllProvinceNameOperationCompleted, userState);
        }
        
        private void OnGetAllProvinceNameOperationCompleted(object arg) {
            if ((this.GetAllProvinceNameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllProvinceNameCompleted(this, new GetAllProvinceNameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.wufish.com/WebService/GetCityName", RequestNamespace="http://www.wufish.com/WebService/", ResponseNamespace="http://www.wufish.com/WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetCityName(string ProName) {
            object[] results = this.Invoke("GetCityName", new object[] {
                        ProName});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetCityNameAsync(string ProName) {
            this.GetCityNameAsync(ProName, null);
        }
        
        /// <remarks/>
        public void GetCityNameAsync(string ProName, object userState) {
            if ((this.GetCityNameOperationCompleted == null)) {
                this.GetCityNameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCityNameOperationCompleted);
            }
            this.InvokeAsync("GetCityName", new object[] {
                        ProName}, this.GetCityNameOperationCompleted, userState);
        }
        
        private void OnGetCityNameOperationCompleted(object arg) {
            if ((this.GetCityNameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCityNameCompleted(this, new GetCityNameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.wufish.com/WebService/GetTownName", RequestNamespace="http://www.wufish.com/WebService/", ResponseNamespace="http://www.wufish.com/WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetTownName(string ProName, string CityName) {
            object[] results = this.Invoke("GetTownName", new object[] {
                        ProName,
                        CityName});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetTownNameAsync(string ProName, string CityName) {
            this.GetTownNameAsync(ProName, CityName, null);
        }
        
        /// <remarks/>
        public void GetTownNameAsync(string ProName, string CityName, object userState) {
            if ((this.GetTownNameOperationCompleted == null)) {
                this.GetTownNameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetTownNameOperationCompleted);
            }
            this.InvokeAsync("GetTownName", new object[] {
                        ProName,
                        CityName}, this.GetTownNameOperationCompleted, userState);
        }
        
        private void OnGetTownNameOperationCompleted(object arg) {
            if ((this.GetTownNameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetTownNameCompleted(this, new GetTownNameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.wufish.com/WebService/GetCityCode", RequestNamespace="http://www.wufish.com/WebService/", ResponseNamespace="http://www.wufish.com/WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetCityCode(string ProName, string CityName) {
            object[] results = this.Invoke("GetCityCode", new object[] {
                        ProName,
                        CityName});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetCityCodeAsync(string ProName, string CityName) {
            this.GetCityCodeAsync(ProName, CityName, null);
        }
        
        /// <remarks/>
        public void GetCityCodeAsync(string ProName, string CityName, object userState) {
            if ((this.GetCityCodeOperationCompleted == null)) {
                this.GetCityCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCityCodeOperationCompleted);
            }
            this.InvokeAsync("GetCityCode", new object[] {
                        ProName,
                        CityName}, this.GetCityCodeOperationCompleted, userState);
        }
        
        private void OnGetCityCodeOperationCompleted(object arg) {
            if ((this.GetCityCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCityCodeCompleted(this, new GetCityCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.wufish.com/WebService/GetCityNameByPostCode", RequestNamespace="http://www.wufish.com/WebService/", ResponseNamespace="http://www.wufish.com/WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetCityNameByPostCode(string PostCode) {
            object[] results = this.Invoke("GetCityNameByPostCode", new object[] {
                        PostCode});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetCityNameByPostCodeAsync(string PostCode) {
            this.GetCityNameByPostCodeAsync(PostCode, null);
        }
        
        /// <remarks/>
        public void GetCityNameByPostCodeAsync(string PostCode, object userState) {
            if ((this.GetCityNameByPostCodeOperationCompleted == null)) {
                this.GetCityNameByPostCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCityNameByPostCodeOperationCompleted);
            }
            this.InvokeAsync("GetCityNameByPostCode", new object[] {
                        PostCode}, this.GetCityNameByPostCodeOperationCompleted, userState);
        }
        
        private void OnGetCityNameByPostCodeOperationCompleted(object arg) {
            if ((this.GetCityNameByPostCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCityNameByPostCodeCompleted(this, new GetCityNameByPostCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.wufish.com/WebService/GetCityNameByTelCode", RequestNamespace="http://www.wufish.com/WebService/", ResponseNamespace="http://www.wufish.com/WebService/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetCityNameByTelCode(string TelCode) {
            object[] results = this.Invoke("GetCityNameByTelCode", new object[] {
                        TelCode});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetCityNameByTelCodeAsync(string TelCode) {
            this.GetCityNameByTelCodeAsync(TelCode, null);
        }
        
        /// <remarks/>
        public void GetCityNameByTelCodeAsync(string TelCode, object userState) {
            if ((this.GetCityNameByTelCodeOperationCompleted == null)) {
                this.GetCityNameByTelCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCityNameByTelCodeOperationCompleted);
            }
            this.InvokeAsync("GetCityNameByTelCode", new object[] {
                        TelCode}, this.GetCityNameByTelCodeOperationCompleted, userState);
        }
        
        private void OnGetCityNameByTelCodeOperationCompleted(object arg) {
            if ((this.GetCityNameByTelCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCityNameByTelCodeCompleted(this, new GetCityNameByTelCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetAllProvinceNameCompletedEventHandler(object sender, GetAllProvinceNameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllProvinceNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllProvinceNameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetCityNameCompletedEventHandler(object sender, GetCityNameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCityNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCityNameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetTownNameCompletedEventHandler(object sender, GetTownNameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetTownNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetTownNameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetCityCodeCompletedEventHandler(object sender, GetCityCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCityCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCityCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetCityNameByPostCodeCompletedEventHandler(object sender, GetCityNameByPostCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCityNameByPostCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCityNameByPostCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void GetCityNameByTelCodeCompletedEventHandler(object sender, GetCityNameByTelCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCityNameByTelCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCityNameByTelCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591