using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEcsponate : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ecsponate = new List<GameObject>();

    private BDLecture _bd;

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        _bd = BDLectures.instance.GetBD();

        StartCoroutine(Creator());
        IEnumerator Creator()
        {
            foreach (var item in _bd.Lectures)
            {
                if (item.Ecsponat != null)
                {
                    GameObject _myE = Instantiate(item.Ecsponat, transform);
                    _ecsponate.Add(_myE);
                    _myE.SetActive(false);
                }
                else _ecsponate.Add(null);
            }
            yield return null;
        }
    }
    public void ActiveEcsponate(int index)
    {
        Debug.Log(_ecsponate[index].name);
        GameObject _currentE = _ecsponate[index];
        _currentE.SetActive(true);
    }
    public void CloseEcsponate(int index)
    {
        Debug.Log(_ecsponate[index].name);
        GameObject _currentE = _ecsponate[index];
        _currentE.SetActive(false);
    }
}
