using System;

namespace BattleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            LivingBeing Player = new LivingBeing("Player", 1, 100, 5);
            LivingBeing Enemy = new LivingBeing("Enemy", 1, 100, 5);

            Battle battle = new Battle(ref Player, ref Enemy);

            while (battle.BattleInProgress)
            {
                battle.NextTurn();
            }

            Console.WriteLine("The winner is " + battle.Winner.Name + "!");
        }
    }
}
