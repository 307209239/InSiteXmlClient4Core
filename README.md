# InSiteXmlClient4Core
工作原因经常使用camstar的 InsiteXMLClient类库做二次开发，但是只能在4.X环境下使用，对于日益繁荣的.net core生态，花费了些时间把原有的类库重新封装为.net core 类库，并在实际环境中测试通过。

1.类库不再使用camstar的命名方式，接口统一以I开头

2.把原有的依赖库，统一集成到一个类库里面

3.重新封装了调用过程（CamstarCommon类），使得调用API更为简单

4.添加扩展方法（CamstarCommonEx类），给DataField赋值不用再转换为string类型

使用方式
var  client=new CamstarCommon("192.168.1.50",2881,"admin","admin");


使用start服务


  var common = new CamstarCommon("192.168.1.50",2881,"admin","admin");
  
  common.CreateService("LotStart");
  
  var inputdata = common.InputData();
  
  inputdata.DataField("AutoPrepare").SetValue(false);
  
  inputdata.DataField("AutoSetNewLotId").SetValue(false);
  
  inputdata.DataField("ComputerName").SetValue(model.ComputerName);
  
  inputdata.DataField("ContainerName").SetValue(model.ContainerName);
  
  inputdata.DataField("CycleTime").SetValue(1);
  
  inputdata.DataField("ExpectedStartDate").SetValue(DateTime.Now);
  
  inputdata.NamedObjectField("Factory").SetRef(model.Factory);
  
  inputdata.DataField("IsEShip").SetValue(false);
  
  inputdata.NamedSubentityField("FirstWIPStep").SetName(model.FirstWIPStep);
  
  inputdata.RevisionedObjectField("FirstWIPStepWorkflow")
  
      .SetRef(model.Product.Name, model.Product.Revision, false);
      
  inputdata.NamedObjectField("Owner").SetRef(model.Owner);
  
  inputdata.RevisionedObjectField("Product").SetRef(model.Product.Name, model.Product.Revision, false);
  
  inputdata.DataField("Qty").SetValue(model.Qty);
  
  inputdata.DataField("Qty2").SetValue(model.Qty2);
  
  inputdata.DataField("Qty3").SetValue(model.Qty3);
  
  inputdata.NamedObjectField("UOM").SetRef(model.UOM);
  
  inputdata.NamedObjectField("UOM2").SetRef(model.UOM2);
  
  inputdata.NamedObjectField("UOM3").SetRef(model.UOM3);
  
  inputdata.RevisionedObjectField("ProcessSpec").SetRef(model.Product.Name, model.Product.Revision, false);
  
  inputdata.DataField("AutoPrepare").SetValue("true");
  
  inputdata.DataField("ComputerName").SetValue(model.ComputerName);
  
  inputdata.NamedObjectField("Employee").SetRef(model.Employee);
  
  inputdata.NamedObjectField("MfgOrder").SetRef(model.MfgOrder);
  
  inputdata.RevisionedObjectField("Workflow").SetRef(model.Workflow.Name, model.Workflow.Revision, false);
  
  var step = inputdata.NamedSubentityField("WorkFlowStep");
  
  step.SetName(model.WorkflowStep);
  
  step.ParentInfo().SetRevisionedObjectRef(model.Workflow.Name, model.Workflow.Revision, false);
  
  inputdata.NamedObjectField("StartReason").SetRef(model.StartReason);
  
  inputdata.NamedObjectField("PriorityCode").SetRef(model.PriorityCode);
  
  inputdata.DataField("SalesOrderNumber").SetValue(model.SalesOrder);
  
  inputdata.DataField("fpBarCode").SetValue(model.fpBarCode);
  
  inputdata.NamedObjectField("Level").SetRef(model.Level);
  
  inputdata.DataField("fpKey").SetValue(model.fpKey);
  
  var wafers = inputdata.SubentityList("Wafers");
  
  foreach (var wafer in model.Wafers)
  {
  
      var item = wafers.AppendItem();
      
      item.DataField("Qty").SetValue(wafer.Qty);
      
      item.DataField("Qty2").SetValue(wafer.Qty2);
      
      item.DataField("NDPW").SetValue(wafer.Qty);
      
      item.DataField("Qty3").SetValue(wafer.Qty3);
      
      item.DataField("WaferNumber").SetValue(wafer.WaferNumber);
      
      item.DataField("WaferScribeNumber").SetValue(wafer.WaferNumber);
      
      item.DataField("RequireTracking").SetValue("True");
      
  }
  
  return await common.ExecuteResultAsync();
  
  可进行打赏，付费进行camstar API 咨询
| | | 
|--|--|
| ![image.jgp](https://github.com/307209239/pay/blob/master/e6c8467a282ece0b6a73627f9e7c4e3.jpg)| ![image.jpg](https://github.com/307209239/pay/blob/master/e753183955236b6eafa6210a622afa4.jpg)| 
