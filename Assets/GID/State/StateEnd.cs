using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEnd : StateGID
{
    BDLecture _bd;
    private void OnEnable()
    {
        _bd = BDLectures.instance.GetBD();
    }
    public override void Run()
    {
        GID.OnSetClip?.Invoke(_bd.End.LectureClip);
    }
}
