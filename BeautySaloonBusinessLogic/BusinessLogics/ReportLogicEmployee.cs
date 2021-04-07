using BeautySaloonBusinessLogic.BindingModels;
using BeautySaloonBusinessLogic.HelperModels;
using BeautySaloonBusinessLogic.Interfaces;
using BeautySaloonBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BeautySaloonBusinessLogic.BusinessLogics
{
    public class ReportLogicEmployee
    {
        private readonly IReceiptStorage _receiptStorage;

        private readonly IDistributionStorage _distributionStorage;

        private readonly IEmployeeStorage _employeeStorage;

        public ReportLogicEmployee(IReceiptStorage receiptStorage, IDistributionStorage distributionStorage, IEmployeeStorage employeeStorage)
        {
            _receiptStorage = receiptStorage;
            _distributionStorage = distributionStorage;
            _employeeStorage = employeeStorage;
        }

        /// <summary>
        /// Получение списка косметики за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportCosmeticsViewModel> GetCosmetics(ReportBindingModel model)
        {
            var listReceipts = _receiptStorage.GetFilteredList(new ReceiptBindingModel { DateFrom = model.DateFrom, DateTo = model.DateTo });
            var listAll = new List<ReportCosmeticsViewModel>();
            foreach (var receipt in listReceipts)
            {
                foreach (var rc in receipt.ReceiptCosmetics)
                {
                    var employee = _employeeStorage.GetElement(new EmployeeBindingModel { Id = receipt.EmployeeId });
                    listAll.Add(new ReportCosmeticsViewModel
                    {
                        TypeOfService = "Чек",
                        DateOfService = receipt.PurchaseDate,
                        CosmeticName = rc.Value.Item1,
                        Count = rc.Value.Item2,
                        EmployeeName = employee.F_Name + " " + employee.L_Name
                    });
                }
            }
            var listDistributions = _distributionStorage.GetFilteredList(new DistributionBindingModel { DateFrom = model.DateFrom, DateTo = model.DateTo });
            foreach (var distribution in listDistributions)
            {
                foreach (var dc in distribution.DistributionCosmetics)
                {
                    var employee = _employeeStorage.GetElement(new EmployeeBindingModel { Id = distribution.EmployeeId });
                    listAll.Add(new ReportCosmeticsViewModel
                    {
                        TypeOfService = "Выдача",
                        DateOfService = distribution.IssueDate,
                        CosmeticName = dc.Value.Item1,
                        Count = dc.Value.Item2,
                        EmployeeName = employee.F_Name + " " + employee.L_Name
                    });
                }
            }
            return listAll;
        }

        /// <summary>
        /// Сохранение косметики в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveCosmeticsToPdfFile(ReportBindingModel model)
        {
            SaveToPdfEmployee.CreateDoc(new PdfInfoEmployee
            {
                FileName = model.FileName,
                Title = "Список косметики",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Cosmetics = GetCosmetics(model)
            });
        }
    }
}