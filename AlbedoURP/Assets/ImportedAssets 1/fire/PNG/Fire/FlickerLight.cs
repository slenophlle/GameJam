using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    public Light2D fireLight;  // Light2D bile�eni
    public float minIntensity = 0.8f;  // I����n minimum parlakl�k de�eri
    public float maxIntensity = 1.2f;  // I����n maksimum parlakl�k de�eri
    public float flickerSpeed = 0.1f;  // Titre�im h�z�n� belirleyen s�re

    private void Start()
    {
        if (fireLight == null)
        {
            fireLight = GetComponent<Light2D>();  // Light2D bile�enini al
        }

        // Titre�im efektini ba�lat
        StartCoroutine(FlickerFire());
    }

    IEnumerator FlickerFire()
    {
        while (true)
        {
            // I��k yo�unlu�unu rastgele ayarla
            fireLight.intensity = Random.Range(minIntensity, maxIntensity);

            // Rastgele ���k yar��ap� de�i�imi (iste�e ba�l�)
            fireLight.pointLightOuterRadius = Random.Range(2.5f, 3.5f);

            // I����n scale de�erini rastgele de�i�tir (X ve Y ekseni)
            fireLight.transform.localScale = new Vector3(Random.Range(6f, 10f), Random.Range(6f, 10f), 1f);

            // Rastgele s�re kadar bekle
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
