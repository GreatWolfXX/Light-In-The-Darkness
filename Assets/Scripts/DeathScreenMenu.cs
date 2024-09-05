using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenMenu : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void QuitToMainMenuGame()
    {
        SceneManager.LoadScene(0);;
    }
}