using CannedFactoryContracts.BindingModels;
using CannedFactoryContracts.StoragesContracts;
using CannedFactoryContracts.ViewModels;
using CannedFactoryDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedFactoryDatabaseImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        public List<ImplementerViewModel> GetFullList()
        {
            using var context = new CannedFactoryDatabase();
            return context.Implementers
            .Select(CreateModel)
            .ToList();
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CannedFactoryDatabase();
            return context.Implementers
            .Where(rec => rec.Id.Equals(model.Id))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CannedFactoryDatabase();
            var implementer = context.Implementers
            .FirstOrDefault(rec => rec.Id == model.Id || rec.FIO == model.FIO);
            return implementer != null ? CreateModel(implementer) : null;
        }

        public void Insert(ImplementerBindingModel model)
        {
            using var context = new CannedFactoryDatabase();
            context.Implementers.Add(CreateModel(model, new Implementer()));
            context.SaveChanges();
        }

        public void Update(ImplementerBindingModel model)
        {
            using var context = new CannedFactoryDatabase();
            var element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(ImplementerBindingModel model)
        {
            using var context = new CannedFactoryDatabase();
            Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Implementers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.FIO = model.FIO;
            implementer.TimeWork = model.TimeWork;
            implementer.TimeRest = model.TimeRest;
            return implementer;
        }

        private static ImplementerViewModel CreateModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                FIO = implementer.FIO,
                WorkingTime = implementer.TimeWork,
                PauseTime = implementer.TimeRest                
            };
        }
    }
}
