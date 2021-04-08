using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Contracts
{
    public class DriverRepository : IRepository<IRacer>
    {
        private readonly Dictionary<string, IRacer> models;
        public DriverRepository()
        {
            models = new Dictionary<string, IRacer>();
        }
        public void Add(IRacer model)
        {
            if (models.ContainsKey(model.Name))
            {
                throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.DriversExists, model.Name));
            }
            models.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRacer> GetAll()
        {
            return models.Values.ToList().AsReadOnly();
        }

        public IRacer GetByName(string name)
        {
            return models.FirstOrDefault(m => m.Key == name).Value;
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model.Name);
        }
    }
}
