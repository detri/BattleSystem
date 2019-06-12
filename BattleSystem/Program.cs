using System;

namespace BattleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player("Player", 1, 100, 5);
            var enemy = new LivingBeing("Enemy", 1, 100, 5);

            var battle = new Battle(player, enemy);

            while (player.IsInBattle)
            {
                battle.NextTurn();
            }

            Console.WriteLine($"The winner is {battle.Winner.Name}!");
        }
    }
}
