using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //싱글톤으로 구현
    public AudioSource audioSource;
    public AudioSource audioSource2;
    [SerializeField] private AudioClip[] backgroundMusic = null;
    private int nowBGM = 0;
    public static AudioManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        if (audioSource2.isPlaying == false)
        {
            PlayNextBGM();
        }
    }
    public void SoundPlay(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
    private void PlayNextBGM()
    {
        if (nowBGM >= backgroundMusic.Length)
        {
            nowBGM = 0;
        }
        audioSource2.clip = backgroundMusic[nowBGM];
        audioSource2.Play();
        nowBGM++;
    }
}
