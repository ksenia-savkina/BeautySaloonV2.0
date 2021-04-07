using BeautySaloonBusinessLogic.BindingModels;
using BeautySaloonBusinessLogic.Interfaces;
using BeautySaloonBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySaloonBusinessLogic.BusinessLogics
{
    public class DistributionLogic
    {
        private readonly IDistributionStorage _distributionStorage;

        public DistributionLogic(IDistributionStorage distributionStorage)
        {
            _distributionStorage = distributionStorage;
        }

        public List<DistributionViewModel> Read(DistributionBindingModel model)
        {
            if (model == null)
            {
                return _distributionStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DistributionViewModel> { _distributionStorage.GetElement(model) };
            }
            return _distributionStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(DistributionBindingModel model)
        {
            var element = _distributionStorage.GetElement(new DistributionBindingModel { IssueDate = model.IssueDate });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже произведена выдача в данное время");
            }
            if (model.Id.HasValue)
            {
                _distributionStorage.Update(model);
            }
            else
            {
                _distributionStorage.Insert(model);
            }
        }

        public void Delete(DistributionBindingModel model)
        {
            var element = _distributionStorage.GetElement(new DistributionBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Выдача не найдена");
            }
            _distributionStorage.Delete(model);
        }
    }
}