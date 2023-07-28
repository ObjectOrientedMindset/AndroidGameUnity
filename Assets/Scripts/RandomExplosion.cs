using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExplosion : MonoBehaviour
{
    //Play a random explosion sound for each colliding objects
    private AudioSource source;
    public AudioClip[] randExplo;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        int randSound = Random.Range(0, randExplo.Length);
        source.clip = randExplo[randSound];
        source.Play();
    }

}
