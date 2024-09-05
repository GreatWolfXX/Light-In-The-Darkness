using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    private UI _ui;

    private void Awake()
    {
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    public void PlayGame()
    {
        _ui.isMenuPanelActive = false;
        _ui.isPlayBtnMenuPanelActive = true;
    }
    
    public void GoToTheMenu()
    {
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }
}
