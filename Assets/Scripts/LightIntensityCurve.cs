using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityCurve : MonoBehaviour
{
    public AnimationCurve intensityCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public float duration = 2f;

    private UnityEngine.Rendering.Universal.Light2D light2D;
    private float startTime;

    void Start()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        startTime = Time.time;
    }

    void Update()
    {
        // Calculate the normalized time (0 to 1) based on the duration
        float normalizedTime = Mathf.Clamp01((Time.time - startTime) / duration);

        // Evaluate the intensity curve at the normalized time
        float curveValue = intensityCurve.Evaluate(normalizedTime);

        // Set the light intensity using the evaluated curve value
        light2D.intensity = curveValue;

        // If the animation is complete, reset the start time for looping
        if (normalizedTime >= 1f)
        {
            startTime = Time.time;
        }
    }
}
