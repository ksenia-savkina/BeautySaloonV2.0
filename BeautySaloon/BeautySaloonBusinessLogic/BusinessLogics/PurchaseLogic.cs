﻿using BeautySaloonBusinessLogic.BindingModels;
using BeautySaloonBusinessLogic.Interfaces;
using BeautySaloonBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautySaloonBusinessLogic.BusinessLogic
{
    public class PurchaseLogic
    {
        private readonly IPurchaseStorage _purchaseStorage;

        public PurchaseLogic(IPurchaseStorage purchaseStorage)
        {
            _purchaseStorage = purchaseStorage;
        }

        public List<PurchaseViewModel> Read(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return _purchaseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PurchaseViewModel> { _purchaseStorage.GetElement(model) };
            }
            return _purchaseStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PurchaseBindingModel model)
        {
            var element = _purchaseStorage.GetElement(new PurchaseBindingModel
            {
                Date = model.Date
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть покупка на это время");
            }
            if (model.Id.HasValue)
            {
                _purchaseStorage.Update(model);
            }
            else
            {
                _purchaseStorage.Insert(model);
            }
        }

        public void Delete(PurchaseBindingModel model)
        {
            var element = _purchaseStorage.GetElement(new PurchaseBindingModel
            {
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Покупка  не найдена");
            }
            _purchaseStorage.Delete(model);
        }
    }
}