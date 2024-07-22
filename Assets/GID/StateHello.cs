using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StateHello : StateGID
{
    public override async void Run()
    {
        var _bd = GID.instance.GetBD();
        Debug.Log($"Начало { _bd.Hello.Name}");
        await Task.Delay(5000);
        Debug.Log($"окончание {_bd.Hello.Name}");
        GID.OnNewState(NewState);
    }
}
