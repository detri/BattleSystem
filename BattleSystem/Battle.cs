using System;
namespace BattleSystem
{
    public class Battle
    {
        public LivingBeing turn1Attacker;
        public LivingBeing turn2Attacker;
        public LivingBeing Winner { get; set; }
        public bool BattleInProgress { get; set; }

        public Battle(ref LivingBeing being1, ref LivingBeing being2)
        {
            CalculateAndSetTurnOrder(being1, being2);
            BattleInProgress = true;
        }

        private void CalculateAndSetTurnOrder(LivingBeing being1,
            LivingBeing being2)
        {
            if (being1.Speed == being2.Speed)
            {
                turn1Attacker = being1;
                turn2Attacker = being2;
            }
            else if (being1.Speed > being2.Speed)
            {
                turn1Attacker = being1;
                turn2Attacker = being2;
            }
            else
            {
                turn1Attacker = being2;
                turn2Attacker = being1;
            }
        }

        public void NextTurn()
        {
            bool continueBattle = CheckBattleProgress();

            if (continueBattle)
            {
                int turn1AttackerDamage = turn1Attacker.CalculateAttackDamage();
                turn2Attacker.HP -= turn1AttackerDamage;
                Console.WriteLine(turn1Attacker.AttackMessage(turn1AttackerDamage));
            }
            else
            {
                return;
            }

            continueBattle = CheckBattleProgress();

            if (continueBattle)
            {
                int turn2AttackerDamage = turn2Attacker.CalculateAttackDamage();
                turn1Attacker.HP -= turn2AttackerDamage;
                Console.WriteLine(turn2Attacker.AttackMessage(turn2AttackerDamage));
            }
            else
            {
                return;
            }
        }

        private bool CheckBattleProgress()
        {
            if (turn1Attacker.HP < 1)
            {
                BattleInProgress = false;
                Winner = turn2Attacker;
                return false;
            }
            if (turn2Attacker.HP < 1)
            {
                BattleInProgress = false;
                Winner = turn1Attacker;
                return false;
            }

            return true;
        }
    }
}
