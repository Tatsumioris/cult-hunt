using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip AudioClip;
    public FootSteps footsteps;
    public void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = AudioClip;
        AudioSource.Play();
        footsteps = this;
    }
    public void OnDisable()
    {
        AudioSource.clip = null;
        AudioSource.Play();
        AudioSource.Stop();
        Debug.Log("yay");
    }
}
