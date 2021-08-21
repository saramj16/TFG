using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParpadeoLight : MonoBehaviour
{
    float base1 = 0.0f; // start
    float amplitude = 1.0f; // amplitude of the wave
    float phase = 0.0f; // start point inside on wave cycle
    float frequency = 0.5f; // cycle frequency per second

    private Color originalColor;
    void Start()
    {
        originalColor = GetComponent<Light>().color;
    }

    // Update is called once per frame
    void Update()
    {
        Light light = GetComponent<Light>();
        light.color = originalColor * (Wave());
    }

    float Wave()
    {
        float x = (Time.time + phase) * frequency;
        float y;

        x = x - Mathf.Floor(x); // normalized value (0..1)

        y = 1 - (Random.value * 2);

        return (y * amplitude) + base1;
    }
}
