using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Masloboyka : Interactable
{
    private bool _isInteract;
    private const string _end = "End";
    public override void Run()
    {
        if (!_isInteract)
        {
            _isInteract = true;
            Animator.SetTrigger(_stateAnim);
        }
        else
        {
            _isInteract = false;
            Animator.SetTrigger(_end);
        }
    }
}
