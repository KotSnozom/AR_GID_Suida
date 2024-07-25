using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator)),RequireComponent(typeof(Rigidbody))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _isInteract;
    private const string _stateAnim = "IsInteract";
    public virtual void Run()
    {
        _isInteract = !_isInteract;
        _animator.SetBool(_stateAnim, _isInteract);
    }
}
