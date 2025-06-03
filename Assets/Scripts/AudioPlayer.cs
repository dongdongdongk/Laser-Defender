using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private AudioClip shootClip;
    [SerializeField][Range(0f, 1f)] float shootVolume = 1f;

    [Header("Damage")]
    [SerializeField] private AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    [Header("Background Music")]
    [SerializeField] private AudioClip gameMusicClip; // 게임 음악 클립
    [SerializeField] private AudioClip mainMenuMusicClip; // 메인 메뉴 음악 클립
    [SerializeField][Range(0f, 1f)] float musicVolume = 0.5f; // 공통 음악 볼륨

    private AudioSource musicSource; // 배경 음악용 AudioSource

    static AudioPlayer instance;


    void Awake()
    {
        ManageSingleton();
        // AudioSource 컴포넌트 추가
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true; // 배경 음악 반복 재생
    }

    void Start()
{
    // 게임 시작 시 현재 씬이 메인 메뉴인지 확인하고 음악 재생
    if (SceneManager.GetActiveScene().name == "MainMenu")
    {
        PlayMainMenuMusic();
    }
}

    void ManageSingleton()
    {
        // int instanceCount = FindObjectsOfType<AudioPlayer>().Length;

        // if (instanceCount > 1)
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        if (shootClip != null)
        {
            PlayClip(shootClip, shootVolume);
        }
    }

    public void PlayDamageClip()
    {
        if (damageClip != null)
        {
            PlayClip(damageClip, damageVolume);
        }
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

    // 게임 음악 재생
    public void PlayGameMusic()
    {
        if (gameMusicClip != null && musicSource != null)
        {
            musicSource.clip = gameMusicClip;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }
    }

    // 메인 메뉴 음악 재생
    public void PlayMainMenuMusic()
    {
        if (mainMenuMusicClip != null && musicSource != null)
        {
            musicSource.clip = mainMenuMusicClip;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }
    }

    // 음악 중지
    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }
}
