using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Takip edilecek nesne
    public float smoothTime = 0.3f;  // Kameranýn takip etme hýzý (lag miktarý)
    public Vector3 offset;  // Kameranýn hedef nesneye göre ofseti
    private Vector3 velocity = Vector3.zero;  // Geçici deðiþken

    private void LateUpdate()
    {
        if (target == null)
            return;  // Eðer hedef atanmadýysa, geri dön

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.position = smoothedPosition;
    }
}
