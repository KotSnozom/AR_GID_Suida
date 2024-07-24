using UnityEngine;
using UnityEngine.Events;

public class StateSetQuestion : StateGID
{
    public static UnityAction<int> OnSetQuest;
    [SerializeField] private GameObject _questionPanel;
    [SerializeField] private StateGID _nonQuestState;

    private void OnEnable()
    {
        OnSetQuest += SetQuestion;
    }

    private void OnDisable()
    {
        OnSetQuest -= SetQuestion;
    }
    public override void Run()
    {
        var _bd = BDLectures.instance.GetBD();
        _questionPanel.SetActive(true);
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
