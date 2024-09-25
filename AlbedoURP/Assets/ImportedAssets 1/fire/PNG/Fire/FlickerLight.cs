using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    public Light2D fireLight;  // Light2D bileþeni
    public float minIntensity = 0.8f;  // Iþýðýn minimum parlaklýk deðeri
    public float maxIntensity = 1.2f;  // Iþýðýn maksimum parlaklýk deðeri
    public float flickerSpeed = 0.1f;  // Titreþim hýzýný belirleyen süre

    private void Start()
    {
        if (fireLight == null)
        {
            fireLight = GetComponent<Light2D>();  // Light2D bileþenini al
        }

        // Titreþim efektini baþlat
        StartCoroutine(FlickerFire());
    }

    IEnumerator FlickerFire()
    {
        while (true)
        {
            // Iþýk yoðunluðunu rastgele ayarla
            fireLight.intensity = Random.Range(minIntensity, maxIntensity);

            // Rastgele ýþýk yarýçapý deðiþimi (isteðe baðlý)
            fireLight.pointLightOuterRadius = Random.Range(2.5f, 3.5f);

            // Iþýðýn scale deðerini rastgele deðiþtir (X ve Y ekseni)
            fireLight.transform.localScale = new Vector3(Random.Range(6f, 10f), Random.Range(6f, 10f), 1f);

            // Rastgele süre kadar bekle
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
