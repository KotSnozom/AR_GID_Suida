using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class StateGame : PlayerState
{
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _dist;
    [SerializeField] private Transform _camera;
    [SerializeField] private MoveMarkerAndInstanceGid _moveMarkerAndInstanceGid;

    private bool _moveGid;
    public override void Init()
    {
        IsThis = true;
    }

    public override void Run()
    {
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed & IsThis)
        {
            Ray ray = new Ray(_camera.position, _camera.forward);
            Debug.DrawRay(_camera.position, _camera.forward * _dist,Color.green);
            if (Physics.Raycast(ray,out RaycastHit hit, _dist, _layer))
            {
                if(hit.transform.TryGetComponent(out Interactable interactable))
                {
                    interactable.Run();
                }
            }
        }
    }

    public void StartMoveGid(InputAction.CallbackContext context)
    {
        if (context.performed & !_moveGid)
        {
            _moveGid = true;
            StartCoroutine(MoverGid());
            Debug.Log("Зажат");
        }
    }

    private IEnumerator MoverGid()
    {
        while (_moveGid)
        {
            _moveMarkerAndInstanceGid.MoverGid();
            yield return null;
        }
    }
    public void EndMoveGid(InputAction.CallbackContext context)
    {
        if (context.performed & _moveGid)
        {
            _moveGid = false;
            StopCoroutine(MoverGid());
            Debug.Log("Не зажат");
        }
    }
}
