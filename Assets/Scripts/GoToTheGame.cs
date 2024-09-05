using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTheGame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(33f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}