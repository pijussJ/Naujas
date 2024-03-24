using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CircleDancer : MonoBehaviour
{
    public GameObject prefab;
    [Range(1, 50)] public int count = 10;
    [Range(1f, 15f)] public float radius = 5;
    [Range(-100, 100)] public float rotateSpeed = 100;
    [Range(0f, 10f)] public float sensitivity = 1;
    [Range(0f, 5f)]public float boost = 1;
    [Range(0, 1)] public float minScale = 0.2f;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var angle = (float)i / count * Mathf.PI * 2f;
            var pos = new Vector3();
            pos.x = Mathf.Cos(angle);
            pos.y = Mathf.Sin(angle);
            pos *= radius;
            Instantiate(prefab, pos, Quaternion.identity, transform);
        }

        Analyzer.onVolumeChanged.AddListener(Dance);
    }
    void Dance(float volume)
    {
        transform.Rotate(0, 0, Mathf.Pow(volume * boost, sensitivity) * rotateSpeed);
        transform.localScale = Vector3.one * (volume + minScale);
    }
}
