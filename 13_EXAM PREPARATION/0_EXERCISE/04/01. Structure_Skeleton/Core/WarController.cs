using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
using System.Text;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> party;
        private List<Item> pool;
        public WarController()
        {
            party = new List<Character>();
            pool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            Character character;
            switch (characterType.ToLower())
            {
                case "warrior":
                    character = new Warrior(name);
                    break;
                case "priest":
                    character = new Priest(name);
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            party.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item;
            switch (itemName.ToLower())
            {
                case "firepotion":
                    item = new FirePotion();
                    break;
                case "healthpotion":
                    item = new HealthPotion();
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
            pool.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = party.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (pool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            Item item = pool[pool.Count-1];
            pool.Remove(item);
            character.Bag.AddItem(item);
            return string.Format(SuccessMessages.PickUpItem, character.Name, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = party.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            character.UseItem(character.Bag.GetItem(itemName));
            return string.Format(SuccessMessages.UsedItem, character.Name, itemName);
        }

        public string GetStats()
        {
            List<Character> sortedParty = party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (Character character in sortedParty)
            {
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, 
                                                                            character.Name, 
                                                                            character.Health, 
                                                                            character.BaseHealth,
                                                                            character.Armor,
                                                                            character.BaseArmor,
                                                                            (character.IsAlive == true) ? "Alive" : "Dead"));
            }
            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            Character attacker = party.FirstOrDefault(c => c.Name == attackerName);
            Character receiver = party.FirstOrDefault(c => c.Name == receiverName);
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            if (attacker.AbilityPoints == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
            Warrior warrior = (Warrior)attacker;
            warrior.Attack(receiver);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter,
                                                                        attacker.Name,
                                                                        receiver.Name,
                                                                        attacker.AbilityPoints,
                                                                        receiver.Name,
                                                                        receiver.Health,
                                                                        receiver.BaseHealth,
                                                                        receiver.Armor,
                                                                        receiver.BaseArmor));
            if (!receiver.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }
            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            Character healer = party.FirstOrDefault(c => c.Name == healerName);
            Character receiver = party.FirstOrDefault(c => c.Name == healingReceiverName);
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }
            if (healer.AbilityPoints == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            Priest priest = (Priest)healer;
            priest.Heal(receiver);
            return string.Format(SuccessMessages.HealCharacter,
                                                                healer.Name,
                                                                receiver.Name,
                                                                healer.AbilityPoints,
                                                                receiver.Name,
                                                                receiver.Health);
        }
    }
}
