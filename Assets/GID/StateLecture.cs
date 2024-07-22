using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StateLecture : StateGID
{
    [SerializeField] private StateGID _end;
    public static int _indexLecture;
    public override async void Run()
    {
        var _bd = GID.instance.GetBD();
        Debug.Log(_indexLecture);
        if (_indexLecture < _bd.Lectures.Count)
        {
            Debug.Log($"Начало лекции {_bd.Lectures[_indexLecture].Name}");
            await Task.Delay(5000);
            Debug.Log($"Конец лекции {_bd.Lectures[_indexLecture].Name}");
            _indexLecture++;
            Debug.Log(_indexLecture);
            GID.OnNewState(NewState);
        }
        else GID.OnNewState(_end);
    }
}
