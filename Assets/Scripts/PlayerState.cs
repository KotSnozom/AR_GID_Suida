using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    [SerializeField] protected PlayerState NewState;
    protected bool IsThis;
    public abstract void Run();
    public abstract void Init();
}
