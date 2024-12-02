using System;
using StateMachine;
using UnityEngine;

namespace Enemy.EnemyStateMachine.Transitions
{
    public class ToChaseTransition : AbstractTransition
    {
        private GameObject _player;
        [SerializeField] private Enemy _enemy;

        [SerializeField] private Transform raycastPoint;

        private void Awake()
        {
            _player = GameObject.Find("Player");
        }

        private void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out hit, 16f))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    ShouldTransition = true;
                }
            }
        }
    }
}