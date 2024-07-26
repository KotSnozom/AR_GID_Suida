using UnityEngine;
using UnityEngine.UI;

public class ButtonQuest : MonoBehaviour
{
    [SerializeField] private Text _myText;
    [SerializeField] private Button _questButton;
    [SerializeField] private int _questIndex;

    public void Init(string Name,int index)
    {
        _myText.text = Name;
        _questIndex = index;
        _questButton.onClick.AddListener(SetQuest);
    }
    private void SetQuest()
    {
        StateSetQuestion.OnSetQuest?.Invoke(_questIndex);
    }
}
