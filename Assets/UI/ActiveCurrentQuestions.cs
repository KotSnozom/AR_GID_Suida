using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCurrentQuestions : MonoBehaviour
{
    [SerializeField] private List<RectTransform> _ListQuestionsPanels = new List<RectTransform>();

    public void AddQuestsPanel(RectTransform rectTransform)
    {
        _ListQuestionsPanels.Add(rectTransform);
    }

    public void ActiveCurrentQuests()
    {
        foreach (var item in _ListQuestionsPanels)
        {
            item.gameObject.SetActive(false);
        }

        int _indexLecture = StateLecture.GetIndexLecture() - 1;
        _ListQuestionsPanels[_indexLecture].gameObject.SetActive(true);
    }
}
