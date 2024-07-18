using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateMachin : MonoBehaviour
{
    public static UnityAction<PlayerState> OnNewState;

    [SerializeField] private PlayerState _stateMenu;
    [SerializeField] private PlayerState _moveMarkerAndGid;

    private PlayerState _currentState;
    private void Start()
    {
        OnNewState += SetState;
        SetState(_stateMenu);
    }
    private void Update()
    {
        _currentState.Run();
    }

    private void SetState(PlayerState playerState)
    {
        _currentState = playerState;
        _currentState.Init();
    }
    public void SetGameFromMenu()
    {
        SetState(_moveMarkerAndGid);
    }
}
