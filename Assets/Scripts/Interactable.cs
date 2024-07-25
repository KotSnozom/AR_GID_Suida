using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator)),RequireComponent(typeof(Rigidbody))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected Animator Animator;
    [SerializeField] private bool _isInteract;
    protected const string _stateAnim = "IsInteract";
    public virtual void Run()
    {
        _isInteract = !_isInteract;
        Animator.SetBool(_stateAnim, _isInteract);
    }
}
