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
            float lerpedFreq = Mathf.Lerp(1300f, 1550f, i / 44100f);

            samples[i] = Mathf.Sin(i / 44000f * (Mathf.PI * 2f) * lerpedFreq);
            samples[i] += Mathf.Sin(i / 44000f * (Mathf.PI * 2f) * (lerpedFreq * 1.1f));
            samples[i] /= 2f;

        }

        clip.SetData(samples, 0);



        source.clip = clip;
        source.loop = true;
        source.Play();
    }
}
