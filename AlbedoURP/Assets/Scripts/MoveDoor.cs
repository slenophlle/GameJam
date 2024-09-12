using UnityEngine;
using System.Collections;

public class MoveDoor : MonoBehaviour
{
    public Transform leftDoor; // Sol kap� i�in GameObject'in Transform'u
    public Transform rightDoor; // Sa� kap� i�in GameObject'in Transform'u
    public float moveDistance = 2.0f; // Kap�n�n ne kadar hareket edece�i
    public float moveSpeed = 2.0f; // Kap�n�n hareket h�z�
    private Vector3 leftDoorInitialPosition;
    private Vector3 rightDoorInitialPosition;
    private bool isTriggered = false;

    private void Start()
    {
        // Kap�lar�n ba�lang�� pozisyonlar�n� kaydedin
        leftDoorInitialPosition = leftDoor.position;
        rightDoorInitialPosition = rightDoor.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name); // Tetikleme olup olmad���n� kontrol eder

        if (other.CompareTag("Player") || other.CompareTag("Enemy")) // Tetikleyicinin "Player" tag'ini kontrol edin
        {
            isTriggered = true; // Kap�lar� a�mak i�in tetikleyin
            StartCoroutine(CloseDoorsAfterDelay(3.0f)); // 3 saniye sonra kap�lar� kapat
        }
    }

    private void Update()
    {
        if (isTriggered)
        {
            // Kap�lar� hareket ettirin
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorInitialPosition - Vector3.left * moveDistance, Time.deltaTime * moveSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorInitialPosition - Vector3.right * moveDistance, Time.deltaTime * moveSpeed);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private IEnumerator CloseDoorsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Belirtilen s�re kadar bekle

        // Kap�lar� ba�lang�� konumlar�na geri d�nd�r
        isTriggered = false;
        while (Vector3.Distance(leftDoor.position, leftDoorInitialPosition) > 0.01f || Vector3.Distance(rightDoor.position, rightDoorInitialPosition) > 0.01f)
        {
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorInitialPosition, Time.deltaTime * moveSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorInitialPosition, Time.deltaTime * moveSpeed);
            yield return null; // Bir sonraki frame'i bekle
        }

        // Kap�lar� tam olarak ba�lang�� konumlar�na set et (ufak pozisyon hatalar�n� d�zeltmek i�in)
        leftDoor.position = leftDoorInitialPosition;
        rightDoor.position = rightDoorInitialPosition;
    }
}
