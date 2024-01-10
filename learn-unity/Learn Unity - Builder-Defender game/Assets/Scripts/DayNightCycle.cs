using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    [SerializeField] private float secondsPerDay = 10;

    private Light2D light2D;
    private float daytime;
    private float dayTimeSpeed;

    private void Awake()
    {
       light2D = GetComponent<Light2D>();
        dayTimeSpeed = 1 / secondsPerDay;
    }

    private void Update()
    {
        daytime += Time.deltaTime * dayTimeSpeed;
        light2D.color = gradient.Evaluate(daytime % 1f);
    }
}
