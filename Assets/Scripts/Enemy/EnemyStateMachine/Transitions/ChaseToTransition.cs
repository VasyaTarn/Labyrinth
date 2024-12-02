using StateMachine;
using UnityEngine;

namespace Enemy.EnemyStateMachine.Transitions
{
    public class ChaseToTransition : AbstractTransition
    {
        private GameObject _player;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private float _chaseRadius;

        private void Awake()
        {
            _player = GameObject.Find("Player");
        }

        private void Update()
        {
            if (Vector3.Distance(_player.transform.position, _enemy.transform.position) >= _chaseRadius)
            {
                ShouldTransition = true;
            }
        }
    }
}