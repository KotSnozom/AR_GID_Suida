using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateLecture : StateGID
{
    public static UnityAction OnAddIndex;
    [SerializeField] private StateGID _end;

    [SerializeField] private CreateEcsponate _createEcsponate; 

    private BDLecture _bd;
    private static int _indexLecture;

    private void OnEnable()
    {
        _bd = BDLectures.instance.GetBD();
        OnAddIndex += AddIndex;
    }
    private void OnDisable()
    {
        OnAddIndex -= AddIndex;
    }

    public override void Run()
    {
        StartCoroutine(Lectur());
        IEnumerator Lectur()
        {
            if (_indexLecture < _bd.Lectures.Count)
            {
                Debug.Log(_indexLecture);
                Debug.Log($"������ ������ {_bd.Lectures[_indexLecture].Name}");

                float _time = _bd.Lectures[_indexLecture].LectureClip.length;
                GID.OnSetClip?.Invoke(_bd.Lectures[_indexLecture].LectureClip);

                if (_bd.Lectures[_indexLecture].Ecsponat != null)
                {
                    Debug.Log("��������� ���������");
                    _createEcsponate.ActiveEcsponate(_indexLecture);
                }
                Debug.Log(_time);
                yield return new WaitForSeconds(_bd.Lectures[_indexLecture].LectureClip.length);
                Debug.Log($"����� ������ {_bd.Lectures[_indexLecture].Name}");

                _createEcsponate.CloseEcsponate(_indexLecture);

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
