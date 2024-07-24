using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateQuestion : StateGID
{
    BDLecture _bd;
    int _indexL;
    private void OnEnable()
    {
        _bd = BDLectures.instance.GetBD();
        StateSetQuestion.OnSetQuest += Run;
    }
    public override void Run()
    {

    }
    public void Run(int index)
    {
        _indexL = StateLecture.GetIndexLecture() - 1;
        Debug.Log($"доп вопрос{_indexL} {index}");
        float _time = _bd.Lectures[_indexL].questions[index].AudioClip.length;
        GID.OnSetClip?.Invoke(_bd.Lectures[_indexL].questions[index].AudioClip);

        StartCoroutine(Timer());
        IEnumerator Timer()
        {
            yield return new WaitForSeconds(_time);
            GID.OnNewState?.Invoke(NewState);
        }
    }
}
