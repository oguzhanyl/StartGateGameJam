using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip background;



    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
