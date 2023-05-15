using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextUI : MonoBehaviour
{
    public string currentText { get; private set; } = "";
    TextMeshProUGUI _ui;

    private void Start()
    {
        _ui = GetComponent<TextMeshProUGUI>();
    }


    public void UpdateText(string txt)
    {
        currentText = txt;
        _ui.text = currentText;
    }

    public void Clear()
    {
        currentText = "";
        _ui.text = "";
    }


}
