using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Lecture
{
    public string Name;
    public AudioClip LectureClip;
    public List<Question> questions;
    public GameObject Ecsponat;
}
