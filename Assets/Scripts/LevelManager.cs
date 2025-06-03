using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneDelay = 2f;
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        // 게임 씬 로드 후 게임 음악 재생
        AudioPlayer audioPlayer = FindObjectOfType<AudioPlayer>();
        if (audioPlayer != null)
        {
            audioPlayer.PlayGameMusic();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        // 메인 메뉴 로드 후 메인 메뉴 음악 재생
        AudioPlayer audioPlayer = FindObjectOfType<AudioPlayer>();
        if (audioPlayer != null)
        {
            audioPlayer.PlayMainMenuMusic();
        }
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
        // 씬 로드 후 게임 오버 음악 재생
        if (sceneName == "GameOver")
        {
            AudioPlayer audioPlayer = FindObjectOfType<AudioPlayer>();
            if (audioPlayer != null)
            {
                audioPlayer.PlayMainMenuMusic();
            }
        }
    }
}
