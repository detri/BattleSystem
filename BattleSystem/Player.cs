using System;
namespace BattleSystem
{
    public class Player : LivingBeing
    {
        private readonly ActionParser _actionParser = new ActionParser();
        public bool IsInBattle;
        public bool IsInShop;
        public bool IsInGame = true;

        public Player(string name, int level, int maxHP, int speed)
            : base(name, level, maxHP, speed) { }

        public Action ParseAction(string command)
        {
            return _actionParser.ParseAction(command);
        }
    }
}
