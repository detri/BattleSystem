using System;
namespace BattleSystem
{
    public class LivingBeing
    {
        private readonly float GLOBAL_BASE_DAMAGE = 5.0f;

        private readonly Random RNG = new Random();

        public int HP { get; set; }
        public int MaxHP { get; }
        public int Speed { get; }
        public int Level { get; }
        public int BaseDamage, MaxDamage;
        public string Name;

        public LivingBeing(string Name, int Level, int MaxHP, int Speed)
        {
            this.Name = Name;
            this.MaxHP = MaxHP;
            this.Speed = Speed;
            this.Level = Level;

            CalculateAndSetBaseDamage();

            HP = MaxHP;
        }

        private void CalculateAndSetBaseDamage()
        {
            float Multiplier = Level * 1.5f;
            BaseDamage = (int)Math.Round(GLOBAL_BASE_DAMAGE * Multiplier);
            MaxDamage = (int)Math.Round(BaseDamage * Multiplier);
        }

        public int CalculateAttackDamage()
        {
            return RNG.Next(BaseDamage, MaxDamage);
        }

        public string AttackMessage(int Damage)
        {
            return Name + " attacks for " + Damage.ToString()
                + " damage!";
        }
    }
}
