using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateGID : MonoBehaviour
{
    [SerializeField] protected StateGID NewState;
    public abstract void Run();
}
