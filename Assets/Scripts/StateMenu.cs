using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMenu : PlayerState
{
    public override void Run()
    {
    }
    public void SetNewState()
    {
        StateMachin.OnNewState(NewState);
    }
}
