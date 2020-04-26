using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{

    private AudioSource src;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!src.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
