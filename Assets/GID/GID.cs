using UnityEngine;
using UnityEngine.Events;

public class GID : MonoBehaviour
{
    public static GID instance;

    public static UnityAction<StateGID> OnNewState;
    public static UnityAction<AudioClip> OnSetClip;

    [SerializeField] private AudioSource _source;

    [SerializeField] private StateGID _currentState;
    [SerializeField] private Animator _animator;
    private const string _stateAnim = "State";

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        OnNewState += SetState;
        OnSetClip += SourserClip;
        Debug.Log("инит");
        OnNewState?.Invoke(_currentState);
    }

    private void OnDisable()
    {
        OnNewState -= SetState;
        OnSetClip -= SourserClip;
    }

    private void SourserClip(AudioClip clip)
    {
        _source.clip = clip;
        _source.Play();
    }

    private void SetState(StateGID stateGID)
    {
        _currentState = stateGID;
        Debug.Log(_currentState.GetIndexAnim());
        _animator.SetInteger(_stateAnim,_currentState.GetIndexAnim());

        _currentState.Run();
    }
}