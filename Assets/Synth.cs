using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synth : MonoBehaviour
{
    AudioSource source;
    public float frequency;
    void Start()
    {
        source = GetComponent<AudioSource>();
        var clip = AudioClip.Create("Sin", 44100 * 2, 1, 44100, false);
        var samples = new float[44100 * 2];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Sin(i / 44000f * (Mathf.PI * 2f) * frequency);
        }

        clip.SetData(samples, 0);



        source.clip = clip;
        source.loop = true;
        source.Play();
    }
}
