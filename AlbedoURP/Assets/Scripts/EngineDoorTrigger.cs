using System.Collections;
using UnityEngine;

public class EngineDoorTrigger : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float moveDistance = 2.5f;
    public float moveSpeed = 2.0f;
    public float closeDelay = 3.0f;  // Kapýnýn kapanma gecikmesi
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

        // Eðer Player veya Enemy objesi IDCard aldýysa kapýlarý aç
        if (Collectible.isIDTrigged == true && ((other.CompareTag("Player") || other.CompareTag("Enemy"))))
        {
            if (!isTriggered) // Kapý zaten açýlmamýþsa
            {
                isTriggered = true;  // Kapý açýlma iþlemini tetikle
                StartCoroutine(CloseDoorsAfterDelay(closeDelay)); // Belirtilen süre sonra kapat
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
            gameObject.GetComponent<BoxCollider2D>().enabled = false;  // Kapý açýldýðýnda Collider devre dýþý
        }
    }

    // Kapý açma iþlemi
    private void OpenDoors()
    {
        // Kapýlarý yavaþça aç
        leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorInitialPosition - Vector3.left * moveDistance, Time.deltaTime * moveSpeed);
        rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorInitialPosition - Vector3.right * moveDistance, Time.deltaTime * moveSpeed);
    }

    // Kapýyý belirli bir gecikmeden sonra kapatma iþlemi
    private IEnumerator CloseDoorsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Gecikmeyi bekle

        // Kapý kapatma iþlemini baþlat
        isTriggered = false;

        // Kapýlarý yavaþça kapat
        while (Vector3.Distance(leftDoor.position, leftDoorInitialPosition) > 0.01f || Vector3.Distance(rightDoor.position, rightDoorInitialPosition) > 0.01f)
        {
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorInitialPosition, Time.deltaTime * moveSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorInitialPosition, Time.deltaTime * moveSpeed);
            yield return null;  // Bir sonraki kareyi bekle
        }

        // Kapý pozisyonlarýný tam olarak sýfýrla
        leftDoor.position = leftDoorInitialPosition;
        rightDoor.position = rightDoorInitialPosition;

        // Kapý kapandýktan sonra Collider'ý tekrar aktif et
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
