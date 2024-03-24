using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    [Range(0, 5)]public float rotateSpeed;
    public ParticleSystem boom;
    private void Start()
    {
        Analyzer.onVolumeChanged.AddListener(Dance);
    }
    public void Dance(float volume)
    {
        transform.localScale = new Vector3(volume * 8f, volume * 8f, volume * 8f);
        if (volume >= 0.4f)
        {
            boom.Play();
        }
        transform.Rotate(0, 0, volume * rotateSpeed);
        //transform.position = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(3, 2, 0), volume * 5);
    }
}
