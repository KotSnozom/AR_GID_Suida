using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateGID : MonoBehaviour
{
    [SerializeField] private int BoolAnim;
    [Header("���������")]
    [SerializeField] protected StateGID NewState;
    public abstract void Run();
    public int GetIndexAnim()
    {
        return BoolAnim;
    }
}
