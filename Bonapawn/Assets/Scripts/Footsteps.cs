using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Footsteps : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, audioClip.Length - 1);
        return audioClip[index];
    }
}
