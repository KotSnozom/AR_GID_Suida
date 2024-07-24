using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

public class MoveMarkerAndInstanceGid : PlayerState
{
    [SerializeField] private Text _countHit;
    [SerializeField] private Transform _marker;
    [SerializeField] private GID _gid;
    private Vector3 _newPos;

    [SerializeField] private ARRaycastManager _ARManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private Vector2 _posRay;
    private void Start()
    {
        _posRay = GetScreenPos();
    }

    public override void Run()
    {
        if (_ARManager.Raycast(_posRay, _hits,TrackableType.Planes))
        {
            _newPos = _hits[0].pose.position;
            _marker.position = _newPos;
        }
    }

    private Vector2 GetScreenPos()
    {
        return new Vector2(Screen.width / 2, Screen.height / 2);
    }

    public void InstanceGid(InputAction.CallbackContext context)
    {
        if (context.performed & _hits.Count != 0)
        {
            _gid.transform.position = _hits[0].pose.position;
            _gid.gameObject.SetActive(true);
            StateMachin.OnNewState?.Invoke(NewState);
        }
    }
}
