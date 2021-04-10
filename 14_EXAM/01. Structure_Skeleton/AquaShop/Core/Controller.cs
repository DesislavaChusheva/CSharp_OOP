using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using AquaShop.Utilities.Messages;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Decorations;
using AquaShop.Repositories.Contracts;
using AquaShop.Repositories;
using System.Linq;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorationRepository;
        private List<IAquarium> aquariums;
        public Controller()
        {
            decorationRepository = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            switch (decorationType)
            {
                case "Ornament":
                    decoration = new Ornament();
                    break;
                case "Plant":
                    decoration = new Plant();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            decorationRepository.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            if (!fishType.StartsWith(aquarium.GetType().Name[0]))
            {
                return OutputMessages.UnsuitableWater;
            }
            aquariums.First(a => a.Name == aquariumName).AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            decimal price = 0;
            foreach (IFish fish in aquarium.Fish)
            {
                price += fish.Price;
            }
            foreach (IDecoration decoration in aquarium.Decorations)
            {
                price += decoration.Price;
            }
            return string.Format(OutputMessages.AquariumValue, aquariumName, $"{price:f2}");
        }

        public string FeedFish(string aquariumName)
        {
            aquariums.First(a => a.Name == aquariumName).Feed();
            return string.Format(OutputMessages.FishFed, aquariums.First(a => a.Name == aquariumName).Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorationRepository.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            aquariums.First(a => a.Name == aquariumName).AddDecoration(decoration);
            decorationRepository.Remove(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            string result = null;
            if (aquariums.Count > 0)
            {
                foreach (IAquarium aquarium in aquariums)
                {
                    result += aquarium.GetInfo() + Environment.NewLine;
                }
            }
            return result.Trim();
        }
    }
}
