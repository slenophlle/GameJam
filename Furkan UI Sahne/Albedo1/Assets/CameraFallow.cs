using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakter (veya hedef) referans�
    public float smoothSpeed = 0.125f; // Kamera hareketinin yumu�akl���
    public Vector3 offset; // Kameran�n hedefe olan pozitif mesafesi

    private void LateUpdate()
    {
        // Hedef pozisyonunu hesapla (karakterin pozisyonu art� ofset)
        Vector3 desiredPosition = target.position + offset;

        // Kameran�n mevcut pozisyonuna g�re hedef pozisyona do�ru bir ge�i� yap
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Kameray� yeni pozisyona ta��
        transform.position = smoothedPosition;
    }
}
