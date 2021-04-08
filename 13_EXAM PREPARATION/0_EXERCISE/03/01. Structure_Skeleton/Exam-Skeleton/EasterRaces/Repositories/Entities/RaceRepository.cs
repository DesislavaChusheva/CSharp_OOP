using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Contracts
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly Dictionary<string, IRace> models;
        public RaceRepository()
        {
            models = new Dictionary<string, IRace>();
        }
        public void Add(IRace model)
        {
            if (models.ContainsKey(model.Name))
            {
                throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.RaceExists, model.Name));
            }
            models.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return models.Values.ToList().AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            return models.FirstOrDefault(m => m.Key == name).Value;
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model.Name);
        }
    }
}
