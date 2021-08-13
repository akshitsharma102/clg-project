using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void OnGamePause()
    {
        Time.timeScale = 0f;
        MenuManager.instance.OpenMenu("Pause");
    }
    public void OnGameResumeGame()
    {
        Time.timeScale = 1f;
        MenuManager.instance.OpenMenu("Playing");
    }
    public void OnQuitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }
    public void Lost()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        MenuManager.instance.OpenMenu("Death");
    }

}
