using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MoveMarkerAndInstanceGid : PlayerState
{
    [SerializeField] private Text _countHit;
    [SerializeField] private Transform _marker;
    [SerializeField] private GameObject _gid;
    private Vector3 _newPos;

    [SerializeField] private ARRaycastManager _ARManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private Vector2 _posRay;
    private void Start()
    {
        _posRay = GetScreenPos();
    }
    public override void Init()
    {
        IsThis = true;
    }

    public override void Run()
    {
        if (_ARManager.Raycast(_posRay, _hits,TrackableType.Planes))
        {
            _newPos = _hits[0].pose.position;
            _marker.position = _newPos;
        }
        _countHit.text = _hits.Count.ToString();
        Debug.Log("Типа установка гида");
    }

    private Vector2 GetScreenPos()
    {
        return new Vector2(Screen.width / 2, Screen.height / 2);
    }

    public void InstanceGid()
    {
        GameObject _newGid = Instantiate(_gid, _newPos, Quaternion.identity);
        _newGid.transform.LookAt(Camera.main.transform,Vector3.up);
        StateMachin.OnNewState?.Invoke(NewState);
    }
}
