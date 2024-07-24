using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButtonQuestion : MonoBehaviour
{
    [SerializeField] private ActiveCurrentQuestions _activeQuestions;
    [SerializeField] private ButtonQuest _buttonPrefab;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private RectTransform _content;
    private BDLecture _myBD;
    private void Start()
    {
        _myBD = BDLectures.instance.GetBD();
        StartCoroutine(CreatorQuest());

        IEnumerator CreatorQuest()
        {
            foreach (var lecture in _myBD.Lectures)
            {
                RectTransform _myLecture = Instantiate(_content, _parent.transform);
                _myLecture.name = lecture.Name;
                _activeQuestions.AddQuestsPanel(_myLecture);
                _myLecture.gameObject.SetActive(false);

                int i = 0;
                foreach (var questions in lecture.questions)
                {
                    ButtonQuest _quest = Instantiate(_buttonPrefab, _myLecture);
                    _quest.Init(questions.Name,i);
                    _quest.name = questions.Name;
                    i++;
                }
            }
            yield return null;
        }
    }
}
