using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Contracts
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly Dictionary<string, ICar> models;
        public CarRepository()
        {
            models = new Dictionary<string, ICar>();
        }
        public void Add(ICar model)
        {
            if (models.ContainsKey(model.Model))
            {
                throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.CarExists, model.Model));
            }
            models.Add(model.Model, model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return models.Values.ToList().AsReadOnly();
        }

        public ICar GetByName(string name)
        {
            return models.FirstOrDefault(m => m.Key == name).Value;
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model.Model);
        }
    }
}
 