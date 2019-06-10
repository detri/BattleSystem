using System;

namespace BattleSystem
{
    public class Battle
    {
        public LivingBeing Winner;
        public bool BattleInProgress;

        private LivingBeing _currentAttacker;
        private LivingBeing _currentDefender;

        public Battle(LivingBeing being1, LivingBeing being2)
        {
            CalculateAndSetTurnOrder(being1, being2);
            BattleInProgress = true;
        }

        private void CalculateAndSetTurnOrder(LivingBeing being1,
            LivingBeing being2)
        {
            if (being1.Speed == being2.Speed || being1.Speed > being2.Speed)
            {
                _currentAttacker = being1;
                _currentDefender = being2;
            }
            else
            {
                _currentAttacker = being2;
                _currentDefender = being1;
            }
        }

        public void NextTurn()
        {
            bool continueBattle = CheckBattleProgress();

            if (continueBattle)
            {
                int attackDamage = _currentAttacker.CalculateAttackDamage();
                _currentDefender.HP -= attackDamage;
                Console.WriteLine(_currentAttacker.AttackMessage(attackDamage));
                LivingBeing _previousAttacker = _currentAttacker;
                _currentAttacker = _currentDefender;
                _currentDefender = _previousAttacker;
            }
        }

        private bool CheckBattleProgress()
        {
            if (_currentDefender.HP < 1)
            {
                BattleInProgress = false;
                Winner = _currentAttacker;
                return false;
            }

            return true;
        }
    }
}
