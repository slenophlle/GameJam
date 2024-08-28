using UnityEngine;

public class FlashlightControl : MonoBehaviour
{

    void Update()
    {
        // Fare imlecinin pozisyonunu dünya koordinatlarýna çevir
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Z eksenini sýfýrla, çünkü 2D bir oyun için Z eksenine ihtiyaç yok
        mousePosition.z = 0f;

        // Karakter ile fare arasýndaki yön vektörünü hesapla
        Vector3 direction = mousePosition - transform.position;

        // Rotasyonu hesapla (radyan cinsinden açý) ve karakterin rotasyonunu güncelle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}

