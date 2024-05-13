using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
        audioSource.volume = 0.008f;
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
