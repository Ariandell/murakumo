using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefAudio : MonoBehaviour
{
    public LayerMask layer;
    public AudioClip soundClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & layer) != 0)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = soundClip;
            audioSource.Play();
            audioSource.volume = 0.1f;
            Destroy(audioSource, soundClip.length);
        }
    }
}
