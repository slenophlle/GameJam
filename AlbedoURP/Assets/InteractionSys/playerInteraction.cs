using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactionUI;
    [SerializeField] GameObject MiniGamePanel;
    private bool canInteract = false;
    static GameObject interactedObject;

    private Collectible collectibleItem;

    private void Start()
    {
        interactionUI.SetActive(false);
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScrewDriver") || collision.gameObject.CompareTag("SampleTube") || collision.gameObject.CompareTag("IDcard"))
        {
            interactedObject = collision.gameObject;
            collectibleItem = interactedObject.GetComponent<Collectible>();
            ShowInteractionUI();
        }
        else if (collision.gameObject.CompareTag("Minigame") || collision.gameObject.CompareTag("MinigamÝnf"))
        {
            interactedObject = collision.gameObject;
            ShowInteractionUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Trigger'dan çýktýðýnda etkileþim UI'sýný gizle
        if (collision.gameObject == interactedObject)
        {
            HideInteractionUI();
        }
    }

    private void ShowInteractionUI()
    {
        interactionUI.SetActive(true);
        canInteract = true;
        Cursor.visible = false; // Fare imlecini gizle
    }

    private void HideInteractionUI()
    {
        interactionUI.SetActive(false);
        if (MiniGamePanel != null)
        {
            MiniGamePanel.SetActive(false);
        }

        if (interactedObject != null)
        {
            if (interactedObject.GetComponent<ValuesOfMiniGame>() != null)
            {
                interactedObject.GetComponent<ValuesOfMiniGame>().canvas.SetActive(false);
            }
        }
        canInteract = false;
        interactedObject = null; // Son etkileþim nesnesini sýfýrla
    }

    public void Interact()
    {
        if (interactedObject.name == "MinigameTrigger")
        {
            MiniGamePanel.SetActive(true);
            Cursor.visible = true; // Fare imlecini göster
            Cursor.lockState = CursorLockMode.None; // Ýmlecinin kilidini kaldýr
        }
        else if (interactedObject.CompareTag("MinigamÝnf"))
        {
            Debug.Log(interactedObject.name);
            interactedObject.GetComponent<ValuesOfMiniGame>().canvas.SetActive(true);
        }
        else
        {
            collectibleItem.InteractObject(interactedObject);
        }
    }
}
