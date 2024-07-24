using UnityEngine;

public class BDLectures : MonoBehaviour
{
    public static BDLectures instance;
    [SerializeField] private BDLecture _bdLecture;

    private void Awake()
    {
        instance = this;
    }
    public BDLecture GetBD()
    {
        return _bdLecture;
    }
}
