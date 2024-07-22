using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBD")]
public class BDLecture : ScriptableObject
{
    [SerializeField] private List<Lecture> _lectures = new List<Lecture>();
    [SerializeField] private Lecture _hello;
    [SerializeField] private Lecture _end;
    public List<Lecture> Lectures => _lectures;
    public Lecture Hello => _hello;
    public Lecture End => _end;
}
