using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Analyzer : MonoBehaviour
{
    AudioSource source;
    float[] frame;
    public GameObject cube;
    public static UnityEvent<float> onVolumeChanged = new();

    private void Start()
    {
        source = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        frame = new float[735];
        source.clip.GetData(frame, source.timeSamples);

        float sum = 0f;
        foreach (var sample in frame)
        {
            sum += Mathf.Abs(sample);
        }

        float averageVolume = sum / frame.Length;

        onVolumeChanged.Invoke(averageVolume);
    }
}
