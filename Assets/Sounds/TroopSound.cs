using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheetasoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attack, damage, die;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attack);
    }
    public void PlayDamageSound()
    {
        audioSource.PlayOneShot(damage);
    }
    public void PlayDieSound()
    {
        audioSource.PlayOneShot(die);
    }
}
