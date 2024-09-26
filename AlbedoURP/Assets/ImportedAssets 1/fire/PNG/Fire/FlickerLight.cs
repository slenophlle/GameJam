using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    public Light2D fireLight;
    public ShadowCaster2D shadowCaster;  // Shadow Caster 2D bileþeni
    [Header("Values")]
    [SerializeField] private float minIntensity = 1f;
    [SerializeField] private float maxIntensity = 7.2f;
    [SerializeField] private float flickerSpeed = 0.4f;
    [SerializeField] private float minRadius = 1.0f;
    [SerializeField] private float maxRadius = 2.0f;
    [SerializeField] private float minShadowStrength = 0.1f;  // Minimum gölge gücü
    [SerializeField] private float maxShadowStrength = 1.0f;  // Maksimum gölge gücü
    [SerializeField] public Color minColor;
    [SerializeField] public Color maxColor;

    private void Start()
    {
        if (fireLight == null)
        {
            fireLight = GetComponent<Light2D>();
        }

        if (shadowCaster == null)
        {
            shadowCaster = GetComponent<ShadowCaster2D>();  // Shadow Caster 2D bileþenini al
        }

        StartCoroutine(FlickerFire());
    }

    IEnumerator FlickerFire()
    {
        while (true)
        {
            fireLight.intensity = Random.Range(minIntensity, maxIntensity);
            fireLight.pointLightOuterRadius = Random.Range(minRadius, maxRadius);
            fireLight.color = Color.Lerp(minColor, maxColor, Random.Range(0f, 1f));

            // Gölge gücünü rastgele ayarla
            float randomShadowStrength = Random.Range(minShadowStrength, maxShadowStrength);
            shadowCaster.shadowStrength = randomShadowStrength; // Gölge gücünü ayarla

            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
