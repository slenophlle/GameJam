using UnityEngine;
using System.Collections;

public class MoveDoor : MonoBehaviour
{
    // DoorPrefabs
    public Transform leftDoor;
    public Transform rightDoor;

    // DoorValues
    private float moveDistance = 2.5f;
    private float moveSpeed = 2.5f;

    // DoorStartpositions
    private Vector3 leftDoorInitialPosition;
    private Vector3 rightDoorInitialPosition;

    private bool isTriggered = false;

    private void Start()
    {
        // Kapýlarýn baþlangýç pozisyonlarýný kaydedin
        leftDoorInitialPosition = leftDoor.position;
        rightDoorInitialPosition = rightDoor.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name); // Tetikleme olup olmadýðýný kontrol eder

        if (other.CompareTag("Player") || other.CompareTag("Enemy")) // Tetikleyicinin "Player" tag'ini kontrol edin
        {
            if (!isTriggered) // Kapý zaten açýlmýþsa tekrar açýlmasýn
            {
                isTriggered = true; // Kapýlarý açmak için tetikleyin
                StartCoroutine(CloseDoorsAfterDelay(3.0f)); // 3 saniye sonra kapýlarý kapat
            }
        }
    }

    private void Update()
    {
        if (isTriggered)
        {
            // Kapýlarý hareket ettirin
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorInitialPosition - Vector3.left * moveDistance, Time.deltaTime * moveSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorInitialPosition - Vector3.right * moveDistance, Time.deltaTime * moveSpeed);
            gameObject.GetComponent<BoxCollider2D>().enabled = false; // Collider'ý devre dýþý býrak
        }
    }

    private IEnumerator CloseDoorsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Belirtilen süre kadar bekle

        // Kapýlarý baþlangýç konumlarýna geri döndür
        isTriggered = false; // Kapý kapatma iþlemini baþlat
        while (Vector3.Distance(leftDoor.position, leftDoorInitialPosition) > 0.01f || Vector3.Distance(rightDoor.position, rightDoorInitialPosition) > 0.01f)
        {
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorInitialPosition, Time.deltaTime * moveSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorInitialPosition, Time.deltaTime * moveSpeed);
            yield return null; // Bir sonraki frame'i bekle
        }

        // Kapýlarý tam olarak baþlangýç konumlarýna set et
        leftDoor.position = leftDoorInitialPosition;
        rightDoor.position = rightDoorInitialPosition;

        // Kapý kapandýktan sonra Collider'ý tekrar aktif et
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
