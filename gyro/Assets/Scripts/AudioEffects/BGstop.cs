using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGstop : MonoBehaviour
{
    [SerializeField] AudioSource music;

    public void OffMusic()
    {
        music.Stop();
    }
}
