using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Contracts;
using WarCroft.Constants;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        public Warrior(string name) : base(name, 100, 50, 40, new Satchel())
        {
        }
        public override double BaseHealth { get => 100; }
        public override double BaseArmor { get => 50; }
        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this == character)
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
                }
                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
