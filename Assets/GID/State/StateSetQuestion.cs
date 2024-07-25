using UnityEngine;
using UnityEngine.Events;

public class StateSetQuestion : StateGID
{
    public static UnityAction<int> OnSetQuest;
    [SerializeField] private GameObject _questionPanel;
    [SerializeField] private StateGID _nonQuestState;
    [SerializeField] private ActiveCurrentQuestions _activeQuestions;

    private void OnEnable()
    {
        OnSetQuest += SetQuestion;
        var _bd = BDLectures.instance.GetBD();
    }

    private void OnDisable()
    {
        OnSetQuest -= SetQuestion;
    }
    public override void Run()
    {
        _questionPanel.SetActive(true);
        _activeQuestions.ActiveCurrentQuests();
    }
    public void SetNonQuestion()
    {
        GID.OnNewState?.Invoke(_nonQuestState);
    }
    public void SetQuestion(int index)
    {
        GID.OnNewState?.Invoke(NewState);
    }
}
