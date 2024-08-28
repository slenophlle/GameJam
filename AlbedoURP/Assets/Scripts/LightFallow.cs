using UnityEngine;

public class FlashlightControl : MonoBehaviour
{

    void Update()
    {
        // Fare imlecinin pozisyonunu d�nya koordinatlar�na �evir
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Z eksenini s�f�rla, ��nk� 2D bir oyun i�in Z eksenine ihtiya� yok
        mousePosition.z = 0f;

        // Karakter ile fare aras�ndaki y�n vekt�r�n� hesapla
        Vector3 direction = mousePosition - transform.position;

        // Rotasyonu hesapla (radyan cinsinden a��) ve karakterin rotasyonunu g�ncelle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}

