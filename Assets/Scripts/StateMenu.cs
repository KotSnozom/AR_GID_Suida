using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMenu : PlayerState
{
    public override void Init()
    {
        IsThis = true;
    }

    public override void Run()
    {
    }
    public void SetNewState()
    {
        IsThis = false;
        StateMachin.OnNewState(NewState);
    }
}
