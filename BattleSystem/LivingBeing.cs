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
        public string Name;

        private int _baseDamage;
        private int _maxDamage;

        public LivingBeing(string name, int level, int maxHP, int speed)
        {
            Name = name;
            MaxHP = maxHP;
            Speed = speed;
            Level = level;

            CalculateAndSetBaseDamage();

            HP = MaxHP;
        }

        private void CalculateAndSetBaseDamage()
        {
            float multiplier = Level * 1.5f;
            _baseDamage = (int)Math.Round(GLOBAL_BASE_DAMAGE * multiplier);
            _maxDamage = (int)Math.Round(_baseDamage * multiplier);
        }

        public int CalculateAttackDamage()
        {
            return RNG.Next(_baseDamage, _maxDamage);
        }

        public string AttackMessage(int damage)
        {
            return $"{Name} attacks for {damage.ToString()} damage!";
        }
    }
}
