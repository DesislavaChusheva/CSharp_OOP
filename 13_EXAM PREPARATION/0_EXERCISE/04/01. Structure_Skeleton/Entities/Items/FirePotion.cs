using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        public FirePotion() : base(5)
        {
        }
        public void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                if (character.Health <= 20)
                {
                    character.IsAlive = false;
                }
                else
                {
                    character.Health -= 20;
                }
            }
        }
    }
}
