using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Takip edilecek nesne
    public float smoothTime = 0.3f;  // Kameran�n takip etme h�z� (lag miktar�)
    public Vector3 offset;  // Kameran�n hedef nesneye g�re ofseti
    private Vector3 velocity = Vector3.zero;  // Ge�ici de�i�ken
   
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.position = smoothedPosition;
    }
}
