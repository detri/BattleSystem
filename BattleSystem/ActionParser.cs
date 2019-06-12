using System;
using System.Collections.Generic;

namespace BattleSystem
{
    public class ActionParser
    {
        private readonly List<string> _attackActions = new List<string>();
        private readonly List<string> _defendActions = new List<string>();

        public ActionParser()
        {
            BuildActionLists();
        }

        public Action ParseAction(string action)
        {
            string[] words = action.Split(" ");

            if (words.Length > 1)
            {
                return HandleTwoWords(words[0], words[1]);
            }

            return HandleOneWord(words[0]);
        }

        private Action HandleOneWord(string verb)
        {
            if (_attackActions.Contains(verb))
            {
                return Action.ATTACK;
            }

            if (_defendActions.Contains(verb))
            {
                return Action.DEFEND;
            }

            Console.WriteLine($"I can't {verb}.");
            return Action.UNKNOWN;
        }

        private Action HandleTwoWords(string verb, string noun)
        {
            Console.WriteLine($"I can't {verb} that {noun}.");
            return Action.UNKNOWN;
        }

        private void BuildActionLists()
        {
            _attackActions.Add("attack");
            _attackActions.Add("kill");

            _defendActions.Add("defend");
            _defendActions.Add("block");
            _defendActions.Add("guard");
        }
    }
}
