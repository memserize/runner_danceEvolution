using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwirlEffect : MonoBehaviour
{
    public ParticleSystem[] particles;

    public void PlayEffect()
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Play();
        }


    }

    public void StopEffect()
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Stop();
        }
    }
}
