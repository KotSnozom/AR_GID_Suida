using UnityEngine;

public abstract class StateGID : MonoBehaviour
{
    [SerializeField] private int BoolAnim;
    [Header("Состояния")]
    [SerializeField] protected StateGID NewState;
    public abstract void Run();
    public virtual int GetIndexAnim()
    {
        return BoolAnim;
    }
}
