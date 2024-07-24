using UnityEngine;
using UnityEngine.UI;

public class ButtonQuest : MonoBehaviour
{
    [SerializeField] private Text _myText;
    [SerializeField] private Button _questButton;
    [SerializeField] private RectTransform _questPanel;
    [SerializeField] private int _questIndex;

    public void Init(string Name,int index, RectTransform panel)
    {
        _myText.text = Name;
        _questIndex = index;
        _questPanel = panel;
        _questButton.onClick.AddListener(SetQuest);
    }
    private void SetQuest()
    {
        _questPanel.gameObject.SetActive(false);
        StateSetQuestion.OnSetQuest?.Invoke(_questIndex);
    }
}
