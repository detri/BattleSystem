using System;

namespace BattleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var Player = new LivingBeing("Player", 1, 100, 5);
            var Enemy = new LivingBeing("Enemy", 1, 100, 5);

            var battle = new Battle(Player, Enemy);

            while (battle.BattleInProgress)
            {
                battle.NextTurn();
            }

            Console.WriteLine("The winner is " + battle.Winner.Name + "!");
        }
    }
}
