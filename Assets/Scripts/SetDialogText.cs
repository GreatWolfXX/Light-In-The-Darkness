using System;
using TMPro;
using UnityEngine;

public class SetDialogText : MonoBehaviour
{
    
    private TextMeshProUGUI _text;
    
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetCustomText(String text)
    {
     _text.SetText(text);
     Invoke("ClearText", 4);
    }
    
    private void ClearText()
    {
        _text.SetText("");
    }
}