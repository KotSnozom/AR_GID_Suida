using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateLecture : StateGID
{
    public static UnityAction OnAddIndex;
    [SerializeField] private StateGID _end;

    private List<GameObject> _ecsponate = new List<GameObject>();
    BDLecture _bd;
    private static int _indexLecture;

    private void OnEnable()
    {
        OnAddIndex += AddIndex;

        StartCoroutine(Init());
        IEnumerator Init()
        {
            _bd = BDLectures.instance.GetBD();

            for (int i = 0; i < _bd.Lectures.Count; i++)
            {
                _ecsponate.Add(_bd.Lectures[i].Ecsponat);
            }
            yield return null;
        }
    }
    private void OnDisable()
    {
        OnAddIndex -= AddIndex;
    }

    public override void Run()
    {
        var _bd = BDLectures.instance.GetBD();

        StartCoroutine(Lectur());
        IEnumerator Lectur()
        {
            if (_indexLecture < _bd.Lectures.Count)
            {
                Debug.Log(_indexLecture);
                Debug.Log($"Начало лекции {_bd.Lectures[_indexLecture].Name}");
                float _time = _bd.Lectures[_indexLecture].LectureClip.length;
                GID.OnSetClip?.Invoke(_bd.Lectures[_indexLecture].LectureClip);
                if (_ecsponate[_indexLecture] != null)
                {
                    Debug.Log(_bd.Lectures[_indexLecture].Ecsponat.name);
                }
                Debug.Log(_time);
                yield return new WaitForSeconds(_bd.Lectures[_indexLecture].LectureClip.length);
                Debug.Log($"Конец лекции {_bd.Lectures[_indexLecture].Name}");
                if (_bd.Lectures[_indexLecture].questions.Count != 0)
                {
                    GID.OnNewState(NewState);
                }
                else
                {
                    _indexLecture++;
                    GID.OnNewState(this);
                }
            }
            else GID.OnNewState(_end);
        }
    }

    public void AddIndex()
    {
        _indexLecture++;
        GID.OnNewState(this);
    }

    public static int GetIndexLecture()
    {
        return _indexLecture;
    }
}
