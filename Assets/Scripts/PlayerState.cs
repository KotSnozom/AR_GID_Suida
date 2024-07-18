using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    [SerializeField] protected PlayerState NewState;
    [SerializeField] protected bool IsThis;
    public abstract void Init();
    public abstract void Run();
}
