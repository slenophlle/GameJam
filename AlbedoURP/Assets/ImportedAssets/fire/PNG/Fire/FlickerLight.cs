using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    public Light2D fireLight;
 
    [Header("Values")]
    [SerializeField] private float minIntensity = 1f;
    [SerializeField] private float maxIntensity = 7.2f;
    [SerializeField] private float flickerSpeed = 0.09f;

    private void Start()
    {
        if (fireLight == null)
        {
            fireLight = GetComponent<Light2D>();
        }
        StartCoroutine(FlickerFire());
    }

    IEnumerator FlickerFire()
    {
        while (true)
        {
            fireLight.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
