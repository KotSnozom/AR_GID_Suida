using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StateQuestion : StateGID
{
    public override async void Run()
    {
        var _bd = GID.instance.GetBD();
        await Task.Delay(5000);
        Debug.Log("�������");
        await Task.Delay(1000);
        Debug.Log("��������� ��������");
        GID.OnNewState(NewState);
    }
}
