using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using InSiteXmlClient4Core.Api;
using InSiteXmlClient4Core.InterFace;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace InSiteXmlClient4Core
{
    public class CamstarCommon
    {
        private CsiClient _client;
        private ICsiConnection _connection;
        private ICsiSession _session;
        private ICsiDocument _document;
        private ICsiService _service;
        private Guid _sessionId;
        public Guid SessionId => _sessionId;
        public static IConfiguration Configuration { get; set; }
       

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="factory">工厂</param>
        public CamstarCommon(string factory,IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(factory))
            {
                throw new Exception("工厂参数不能为空");
            }
            var model = GetConfigModel(factory,configuration);
            if (model is InsiteLoginModel loginModel)
            {
                _session = null;
                _client = null;
                _client = new CsiClient();
                _connection = null;

                _sessionId = Guid.NewGuid();
                _connection = _client.CreateConnection(loginModel.Host, loginModel.Port);
                _session = _connection.CreateSession(loginModel.User, loginModel.Password, _sessionId.ToString());
            }
          
        }

        private InsiteLoginModel GetConfigModel(string factory ,IConfiguration configuration=null)
        {
            if (configuration!=null)
            {
                Configuration = configuration;
            }
            else
            {
                Configuration = new ConfigurationBuilder()
                    .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                    .Build();
            }
            
            var model = new InsiteLoginModel();
            model.Host = Configuration["MESFactory:" + factory + ":Host"];
            model.Port =Convert.ToInt32( Configuration["MESFactory:" + factory + ":Port"]??"2281");
            model.User= Configuration["MESFactory:" + factory + ":User"];
            model.Password= Configuration["MESFactory:" + factory + ":Password"];
            return model;
        }
       



        ///// <summary>
        ///// 初始化
        ///// </summary>
        ///// <param name="factory">工厂</param>
        ///// <param name="employee"></param>
        ///// <param name="password"></param>
        //public CamstarCommon(string factory,string employee,string password)

        //{
        //    var model = GetConfigModel(factory);
        //    if (model is InsiteLoginModel loginModel)
        //    {
        //        loginModel.Password = password;
        //        loginModel.User = employee;
        //        _session = null;
        //        _client = null;
        //        _client = new CsiClient();
        //        _connection = null;
        //        _sessionId = Guid.NewGuid();
        //        _connection = _client.CreateConnection(loginModel.Host, loginModel.Port);
        //        _session = _connection.CreateSession(loginModel.User, loginModel.Password, _sessionId.ToString());
        //    }

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>

        public CamstarCommon(string host, int port, string userName, string password)
        {
            _session = null;
            _client = null;
            _client = new CsiClient();
            _connection = null;
            _sessionId = Guid.NewGuid();
            _connection = _client.CreateConnection(host, port);
            _session = _connection.CreateSession(userName, password, _sessionId.ToString());

        }





        #region Document操作
        /// <summary>
        /// 打印Document文档
        /// </summary>

        public void Print()
        {
            _document.Print(true);
        }
        /// <summary>
        /// 提交文档
        /// </summary>
        /// <returns></returns>
        public ICsiDocument Submit()
        {
            return _document.Submit();
        }

        /// <summary>
        /// 提交并返回实体
        /// </summary>
        /// <typeparam name="T">泛型实体类</typeparam>
        /// <returns></returns>
        public T SubmitAndRequestModel<T>() where T : class, new()
        {
            var model = new T();
            var properties = typeof(T).GetProperties();
            var requestData = RequestData();
            foreach (var p in properties)
            {
                requestData.RequestField(p.Name);
            }
            var requestDoc = Submit();

            var sError = "";
            if (requestDoc.CheckErrors()) return null;
            foreach (var field in requestDoc.GetService().ResponseData().GetResponseFields())
            {
                var fieldType = field.GetType().Name;
                var name = ((ICsiXmlElement)field).GetElementName();
                var p = properties.FirstOrDefault(m => m.Name.ToLower() == name.ToLower());
                if (p == null)
                {
                    continue;
                }
                switch (fieldType)
                {
                    case "CsiDataField":
                        var data1 = (ICsiDataField)field;
                        p.SetValue(model, Convert.ChangeType(data1.GetValue(), p.PropertyType));
                        break;
                    case "CsiDataList":
                        var data2 = (ICsiDataList)field;
                        if (data2.HasChildren())
                        {

                        }
                        break;
                    case "CsiNamedObject":
                        var data3 = (ICsiNamedObject)field;
                        p.SetValue(model, Convert.ChangeType(data3.GetRef(), p.PropertyType));
                        break;
                    case "CsiNamedObjectList":
                        var data4 = (ICsiNamedObjectList)field;
                        if (data4.HasChildren())
                        {

                            p.GetSetMethod().Invoke(model, new[] { (from ICsiNamedObject item in data4.GetListItems() select item.GetRef()).ToList() });
                        }
                        break;
                    case "CsiRevisionedObject":
                        var data5 = (ICsiRevisionedObject)field;
                        p.SetValue(model, Convert.ChangeType(data5.GetName(), p.PropertyType));
                        break;
                    case "CsiRevisionedObjectList":
                        var data6 = (ICsiRevisionedObjectList)field;
                        if (data6.HasChildren())
                        {

                            p.GetSetMethod().Invoke(model, new[] { (from ICsiRevisionedObject item in data6.GetListItems() select item.GetName()).ToList() });
                        }
                        break;
                    case "CsiContainer":
                        var data7 = (ICsiContainer)field;
                        p.SetValue(model, Convert.ChangeType(data7.GetName(), p.PropertyType));
                        break;
                    case "CsiContainerList":
                        var data8 = (ICsiContainerList)field;
                        if (data8.HasChildren())
                        {
                            p.GetSetMethod().Invoke(model, new[] { (from ICsiContainer item in data8.GetListItems() select item.GetName()).ToList() });
                        }
                        break;
                }
            }

            return model;
        }




        /// <summary>
        /// 创建文档和服务
        /// </summary>
        /// <param name="documentName">文档名称</param>
        /// <param name="serviceName">服务名称</param>
        public void CreateDocumentAndService(string documentName, string serviceName)
        {
            if (!string.IsNullOrEmpty(documentName.Trim()))
            {
                _session.RemoveDocument(documentName);
                if (_service != null)
                {
                    _service = null;

                }
                _document = _session.CreateDocument(documentName);
                if (!string.IsNullOrEmpty(serviceName.Trim()))
                {
                    _service = _document.CreateService(serviceName);
                }
            }
        }
        /// <summary>
        /// 建立查询
        /// </summary>
        /// <returns></returns>
        public ICsiQuery CreateQuery()
        {
            return _document.CreateQuery();
        }
        #endregion

        #region Service操作封装
        /// <summary>
        /// 执行service的setExecute
        /// </summary>
        public void Execute()
        {
            _service.SetExecute();
        }
        /// <summary>
        /// 执行service的setExecute，并提交文档到服务器，获取返回结果和信息
        /// </summary>
        /// <param name="action">获取信息的方法</param>
        /// <returns></returns>
        public bool Execute(Action<string> action)
        {
            Execute();
            RequestData().RequestField("CompletionMsg");
            var responseDocument = Submit();
            return !responseDocument.CheckErrors();

        }
        /// <summary>
        /// 执行service的setExecute，并提交文档到服务器，获取返回结果信息
        /// </summary>
        /// <returns></returns>
        public (bool Status, string Message) ExecuteResult()
        {
            try
            {
                Execute();
                RequestData().RequestField("CompletionMsg");
                var responseDocument = Submit();
                var b = false;
                var msg = "";
                b = !responseDocument.CheckErrors(s => msg = s);
                return (Status: b, Message: msg);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + ":request:" + this._document.AsXml() + "\nresponse:" +
                                    this._document.ResponseData()?.GetOwnerDocument()?.AsXml());
                ;
            }
           
           

        }
        /// <summary>
        /// 指定service执行的事件
        /// </summary>
        /// <param name="type">事件类型</param>
        /// <returns></returns>
        public ICsiPerform Perform(PerformType type)
        {
            switch (type)
            {
                case PerformType.Load:
                    return _service.Perform("Load");

                case PerformType.New:
                    return _service.Perform("New");

                case PerformType.Change:
                    return _service.Perform("Load");

                case PerformType.Delete:
                    return _service.Perform("delete");
                case PerformType.NewRev:
                    return _service.Perform("NewRev");

                default:
                    return null;
            }



        }
        /// <summary>
        /// 执行事件
        /// </summary>
        /// <param name="evenName">事件名称</param>
        /// <returns></returns>
        public ICsiPerform Perform(string evenName)
        {
            return _service.Perform(evenName);
        }
        /// <summary>
        /// 返回service的requestData
        /// </summary>
        /// <returns></returns>
        public ICsiRequestData RequestData()
        {
            return _service.RequestData();
        }
        /// <summary>
        /// 创建InputData
        /// </summary>
        /// <returns></returns>
        public ICsiObject InputData()
        {
            return _service.InputData();
        }
        /// <summary>
        /// 创建服务，默认文档名称为服务名加Doc
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        public void CreateService(string serviceName)
        {
            CreateDocumentAndService(serviceName + "Doc", serviceName);
        }

        private void GetConfig()
        {
            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                .Build();
        }
        

        #endregion 

        public enum PerformType
        {
            /// <summary>
            /// 载入
            /// </summary>
            Load,
            /// <summary>
            /// 新建
            /// </summary>
            New,
            /// <summary>
            /// 修改
            /// </summary>
            Change,
            /// <summary>
            /// 删除
            /// </summary>
            Delete,
            /// <summary>
            /// 添加新版本
            /// </summary>
            NewRev

        }


    }
}
