using System.Collections;
using UnityEngine;

public class StateHello : StateGID
{
    public override void Run()
    {
        var _bd = BDLectures.instance.GetBD();
        float _time = _bd.Hello.LectureClip.length;

        StartCoroutine(Hello());
        IEnumerator Hello()
        {
            Debug.Log($"Начало { _bd.Hello.Name}");
            GID.OnSetClip?.Invoke(_bd.Hello.LectureClip);
            yield return new WaitForSeconds(_time);
            Debug.Log($"окончание {_bd.Hello.Name}");
            GID.OnNewState?.Invoke(NewState);
        }

    }
}
