using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGame : PlayerState
{
    public override void Init()
    {
        IsThis = true;
    }

    public override void Run()
    {
        Debug.Log("���� ����� ����");
    }
}
