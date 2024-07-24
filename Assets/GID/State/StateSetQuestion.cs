using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class StateSetQuestion : StateGID
{

    [SerializeField] private GameObject _questionPanel;
    [SerializeField] private StateGID _nonQuestState;

    public override void Run()
    {
        var _bd = BDLectures.instance.GetBD();
        _questionPanel.SetActive(true);
    }
    public void SetNonQuestion()
    {
        GID.OnNewState(_nonQuestState);
    }
    public void SetQuestion(int Index)
    {

    }
}
