using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineDoorTrigger : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float moveDistance = 2.0f;
    public float moveSpeed = 2.0f;
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

        if ((Collectible.isIDTrigged && (other.CompareTag("Player") || other.CompareTag("Enemy")))) // Static deðiþkeni kontrol et
        {
            isTriggered = true;  // Kapýlarý açma iþlemini tetikle
            StartCoroutine(CloseDoorsAfterDelay(3.0f));  // 3 saniye sonra kapat
        }
    }

    private void Update()
    {
        if (isTriggered)
        {
            // Kapýlarý hareket ettir
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorInitialPosition - Vector3.left * moveDistance, Time.deltaTime * moveSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorInitialPosition - Vector3.right * moveDistance, Time.deltaTime * moveSpeed);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private IEnumerator CloseDoorsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        isTriggered = false;
        while (Vector3.Distance(leftDoor.position, leftDoorInitialPosition) > 0.01f || Vector3.Distance(rightDoor.position, rightDoorInitialPosition) > 0.01f)
        {
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorInitialPosition, Time.deltaTime * moveSpeed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorInitialPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }

        leftDoor.position = leftDoorInitialPosition;
        rightDoor.position = rightDoorInitialPosition;
    }
}
