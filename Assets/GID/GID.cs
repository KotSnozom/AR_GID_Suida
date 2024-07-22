using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class GID : MonoBehaviour
{
    public static GID instance;
    public static UnityAction<StateGID> OnNewState;
    public static UnityAction<int> OnNewLecture;

    [SerializeField] private AudioSource _audioSourse;

    [SerializeField] private BDLecture _bdLecture;

    [SerializeField] private StateGID _helloState;
    [SerializeField] private StateGID _currentState;

    private static Lecture _currentLecture;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        OnNewState += SetState;
        _currentState = _helloState;
        _currentState.Run();
    }
    private void SetState(StateGID stateGID)
    {
        _currentState = stateGID;
        _currentState.Run();
    }
    public BDLecture GetBD()
    {
        return _bdLecture;
    }
}