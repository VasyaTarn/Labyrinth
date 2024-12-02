using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : AbstractState
{
    private GameObject _player;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    private readonly int _chaseStateHash = Animator.StringToHash("Walk");

    private void Awake()
    {
        _player = GameObject.Find("Player");
    }

    public override void StartState()
    {
        _agent.speed = 3.5f;
        base.StartState();
    }

    private void Update()
    {
        _animator.CrossFade(_chaseStateHash, 0f);
        _agent.SetDestination(_player.transform.position);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
