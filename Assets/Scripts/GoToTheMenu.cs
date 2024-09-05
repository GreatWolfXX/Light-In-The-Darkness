using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTheMenu : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(23f);
        SceneManager.LoadScene(0);
    }
}