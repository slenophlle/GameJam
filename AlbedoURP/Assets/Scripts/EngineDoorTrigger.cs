using System.Collections;
using UnityEngine;

public class EngineDoorTrigger : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float moveDistance = 2.5f;
    public float moveSpeed = 2.0f;
    public float closeDelay = 3.0f;  // Kap�n�n kapanma gecikmesi
    private Vector3 leftDoorInitialPosition;
    private Vector3 rightDoorInitialPosition;
    private bool isTriggered = false;

    private void Start()
    {
        leftDoorInitialPosition = leftDoor.position;
        rightDoorInitialPosition = rightDoor.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        // E�er Player veya Enemy objesi IDCard ald�ysa kap�lar� a�
        if (Collectible.isIDTrigged == true && ((other.CompareTag("Player") || other.CompareTag("Enemy"))))
        {
            if (!isTriggered) // Kap� zaten a��lmam��sa
            {
                isTriggered = true;  // Kap� a��lma i�lemini tetikle
                StartCoroutine(CloseDoorsAfterDelay(closeDelay)); // Belirtilen s�re sonra kapat
                Debug.Log(Collectible.isIDTrigged);
            }
        }
        else
        {
            Debug.Log("IdCard Olmadan Girilmez");
        }
    }

    private void Update()
    {
        if (isTriggered)
        {
            OpenDoors();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;  // Kap� a��ld���nda Collider devre d���
        }
    }

    // Kap� a�ma i�lemi
    private void OpenDoors()
    {
        // Kap�lar� yava��a a�
        leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorInitialPosition - Vector3.left * moveDistance, Time.deltaTime * moveSpeed);
        rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorInitialPosition - Vector3.right * moveDistance, Time.deltaTime * moveSpeed);
    }

    // Kap�y� belirli bir gecikmeden sonra kapatma i�lemi
    private IEnumerator CloseDoorsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Gecikmeyi bekle

        // Kap� kapatma i�lemini ba�lat
        isTriggered = false;

        // Kap�lar� yava��a kapat
        while (Vector3.Distance(leftDoor.position, leftDoorInitialPosition) > 0.01f || Vector3.Distance(rightDoor.position, rightDoorInitialPosition) > 0.01f)
        {
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorInitialPosition, Time.deltaTime * moveSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorInitialPosition, Time.deltaTime * moveSpeed);
            yield return null;  // Bir sonraki kareyi bekle
        }

        // Kap� pozisyonlar�n� tam olarak s�f�rla
        leftDoor.position = leftDoorInitialPosition;
        rightDoor.position = rightDoorInitialPosition;

        // Kap� kapand�ktan sonra Collider'� tekrar aktif et
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
