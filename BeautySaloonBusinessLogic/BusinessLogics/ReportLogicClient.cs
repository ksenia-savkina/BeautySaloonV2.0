namespace BeautySaloonBusinessLogic.BusinessLogics
{
    public class ReportLogicClient
    {
        //private readonly IProcedureStorage _procedureStorage;
        //private readonly IVisitStorage _visitStorage;
        //private readonly IPurchaseStorage _purchaseStorage;
        //public ReportLogic(IProcedureStorage procedureStorage, IVisitStorage visitStorage,
        //    IPurchaseStorage purchaseStorage)
        //{
        //    _procedureStorage = procedureStorage;
        //    _visitStorage = visitStorage;
        //    _purchaseStorage = purchaseStorage;
        //}
        ///// <summary>
        ///// Получение списка компонент с указанием, в каких изделиях используются
        ///// </summary>
        ///// <returns></returns>
        //public List<ReportManufactureComponentViewModel> GetManufactureComponent()
        //{
        //    var manufactures = _manufactureStorage.GetFullList();
        //    var list = new List<ReportManufactureComponentViewModel>();
        //    foreach (var manufacture in manufactures)
        //    {
        //        var record = new ReportManufactureComponentViewModel
        //        {
        //            ManufactureName = manufacture.ManufactureName,
        //            Components = new List<Tuple<string, int>>(),
        //            TotalCount = 0
        //        };
        //        foreach (var component in manufacture.ManufactureComponents)
        //        {
        //            record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
        //            record.TotalCount += component.Value.Item2;
        //        }
        //        list.Add(record);
        //    }
        //    return list;
        //}
        ///// <summary>
        ///// Получение списка заказов за определенный период
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public List<ReportProceduresViewModel> GetProcedures(ReportBindingModel model)
        //{
        //    return _orderStorage.GetFilteredList(new OrderBindingModel
        //    {
        //        DateFrom =
        //   model.DateFrom,
        //        DateTo = model.DateTo
        //    })
        //    .Select(x => new ReportOrdersViewModel
        //    {
        //        DateCreate = x.DateCreate,
        //        ManufactureName = x.ManufactureName,
        //        Count = x.Count,
        //        Sum = x.Sum,
        //        Status = x.Status
        //    })
        //   .ToList();
        //}
        ///// <summary>
        ///// Сохранение компонент в файл-Word
        ///// </summary>
        ///// <param name="model"></param>
        //public void SaveComponentsToWordFile(ReportBindingModel model)
        //{
        //    SaveToWord.CreateDoc(new WordInfo
        //    {
        //        FileName = model.FileName,
        //        Title = "Список выдач",
        //       // Manufactures = _manufactureStorage.GetFullList()
        //    });
        //}
        ///// <summary>
        ///// Сохранение компонент с указаеним продуктов в файл-Excel
        ///// </summary>
        ///// <param name="model"></param>
        //public void SaveProductComponentToExcelFile(ReportBindingModel model)
        //{
        //    SaveToExcel.CreateDoc(new ExcelInfo
        //    {
        //        FileName = model.FileName,
        //        Title = "Список выдач",
        //        //ComponentManufactures = GetManufactureComponent()
        //    });
        //}
        ///// <summary>
        ///// Сохранение заказов в файл-Pdf
        ///// </summary>
        ///// <param name="model"></param>
        //public void SaveOrdersToPdfFile(ReportBindingModel model)
        //{
        //    SaveToPdf.CreateDoc(new PdfInfo
        //    {
        //        FileName = model.FileName,
        //        Title = "Список заказов",
        //        DateFrom = model.DateFrom.Value,
        //        DateTo = model.DateTo.Value,
        //        Procedures = GetProcedures(model)
        //    });
        //}
    }
}