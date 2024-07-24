using System.Collections;
using UnityEngine;

public class StateLecture : StateGID
{
    [SerializeField] private StateGID _end;

    public static int _indexLecture;

    public override void Run()
    {
        var _bd = BDLectures.instance.GetBD();

        StartCoroutine(Lectur());
        IEnumerator Lectur()
        {
            if (_indexLecture < _bd.Lectures.Count)
            {
                Debug.Log($"Начало лекции {_bd.Lectures[_indexLecture].Name}");
                float _time = _bd.Lectures[_indexLecture].LectureClip.length;
                GID.OnSetClip?.Invoke(_bd.Lectures[_indexLecture].LectureClip);
                Debug.Log(_time);
                yield return new WaitForSeconds(_bd.Lectures[_indexLecture].LectureClip.length);
                Debug.Log($"Конец лекции {_bd.Lectures[_indexLecture].Name}");
                _indexLecture++;
                GID.OnNewState(NewState);
            }
            else GID.OnNewState(_end);
        }
    }

    public static int GetIndexLecture()
    {
        return _indexLecture;
    }
}
