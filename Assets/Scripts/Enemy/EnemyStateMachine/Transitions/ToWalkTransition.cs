using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWalkTransition : AbstractTransition
{
    private void Update()
    {
        ShouldTransition = true;
    }
}
