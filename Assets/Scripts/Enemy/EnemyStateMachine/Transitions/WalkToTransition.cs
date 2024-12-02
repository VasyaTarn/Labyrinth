using Enemy;
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToTransition : AbstractTransition
{
    private void Update()
    {
        ShouldTransition = true;
    }
}
