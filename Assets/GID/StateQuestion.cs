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
        Debug.Log("Вопросы");
        await Task.Delay(1000);
        Debug.Log("окончание вопросов");
        GID.OnNewState(NewState);
    }
}
