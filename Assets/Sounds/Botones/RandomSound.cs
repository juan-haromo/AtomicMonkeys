using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{

    [SerializeField] List<AudioClip> randomClips;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        int randomIndex = Random.Range(0, randomClips.Count);
        audioSource.PlayOneShot(randomClips[randomIndex]);
    }
}
