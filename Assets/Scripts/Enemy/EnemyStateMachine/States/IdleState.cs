using StateMachine;
using UnityEngine;

namespace Enemy.EnemyStateMachine.States
{
    public class IdleState : AbstractState
    {
        [SerializeField] private Animator _animator;

        private readonly int _idleStateHash = Animator.StringToHash("Idle");
        
        public override void StartState()
        {
            base.StartState();
        }
        
        private void Update()
        {
            _animator.CrossFade(_idleStateHash, 0f);   
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}