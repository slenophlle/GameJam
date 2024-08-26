using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakter (veya hedef) referansý
    public float smoothSpeed = 0.125f; // Kamera hareketinin yumuþaklýðý
    public Vector3 offset; // Kameranýn hedefe olan pozitif mesafesi

    private void LateUpdate()
    {
        // Hedef pozisyonunu hesapla (karakterin pozisyonu artý ofset)
        Vector3 desiredPosition = target.position + offset;

        // Kameranýn mevcut pozisyonuna göre hedef pozisyona doðru bir geçiþ yap
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Kamerayý yeni pozisyona taþý
        transform.position = smoothedPosition;
    }
}
