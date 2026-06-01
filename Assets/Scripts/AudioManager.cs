using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //싱글톤으로 구현
    public AudioSource audioSource;

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
    public void SoundPlay(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
