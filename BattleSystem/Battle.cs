using System;

namespace BattleSystem
{
    public class Battle
    {
        public LivingBeing Winner;
        public bool BattleInProgress;

        private Player _player;
        private LivingBeing _enemy;

        private LivingBeing _currentAttacker;
        private LivingBeing _currentDefender;

        public Battle(Player player, LivingBeing enemy)
        {
            _player = player;
            _enemy = enemy;

            _player.IsInBattle = true;

            CalculateAndSetTurnOrder();
        }

        private void CalculateAndSetTurnOrder()
        {
            if (_player.Speed == _enemy.Speed || _player.Speed > _enemy.Speed)
            {
                _currentAttacker = _player;
                _currentDefender = _enemy;
            }
            else
            {
                _currentAttacker = _enemy;
                _currentDefender = _player;
            }
        }

        public void NextTurn()
        {
            if (_player.IsInBattle)
            {
                if (_currentAttacker == _player)
                {
                    Console.WriteLine("It's your turn. Make a move!");
                    string command = Console.ReadLine();
                    Action action = _player.ParseAction(command);
                    switch(action)
                    {
                        case Action.ATTACK:
                            AttackTurn();
                            break;
                        default:
                            NextTurn();
                            return;
                    }
                }
                else
                {
                    AttackTurn();
                }
            }

            CheckBattleProgress();
        }

        private void AttackTurn()
        {
            int attackDamage = _currentAttacker.CalculateAttackDamage();
            _currentDefender.HP -= attackDamage;
            Console.WriteLine(_currentAttacker.AttackMessage(attackDamage));
        }

        private void CheckBattleProgress()
        {
            if (_currentDefender.HP < 1)
            {
                _player.IsInBattle = false;
                Winner = _currentAttacker;
            }
            else
            {
                SwapAttackerAndDefender();
            }
        }

        private void SwapAttackerAndDefender()
        {
            LivingBeing _previousAttacker = _currentAttacker;
            _currentAttacker = _currentDefender;
            _currentDefender = _previousAttacker;
        }
    }
}
