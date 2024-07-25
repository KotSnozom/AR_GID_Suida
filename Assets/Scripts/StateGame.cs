using UnityEngine;
using UnityEngine.InputSystem;

public class StateGame : PlayerState
{
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _dist;
    [SerializeField]private Transform _camera;
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
}
