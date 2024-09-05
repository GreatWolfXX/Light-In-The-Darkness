using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    private UI _ui;

    private void Awake()
    {
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }
    
    public void PlayGame()
    {
        _ui.isInfoMenuPanelActive = false;
        _ui.isPlayBtnInfoMenuPanelActive = true;
    }
}
