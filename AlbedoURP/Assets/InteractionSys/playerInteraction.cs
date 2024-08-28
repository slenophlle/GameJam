using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactionUI;
    [SerializeField] GameObject MiniGamePanel;
    private bool canInteract = false;
    static GameObject interactedObject;

    private Collectible collectibleItem;

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            interactionUI.SetActive(true);
            canInteract = true;
            interactedObject = collision.gameObject;
            collectibleItem = interactedObject.GetComponent<Collectible>();
        }

        else if (collision.gameObject.CompareTag("Minigame"))
        {
            interactionUI.SetActive(true);
            canInteract = true;
            interactedObject = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("MinigamÝnf"))
        {
            interactionUI.SetActive(true);
            canInteract = true;
            interactedObject = collision.gameObject;
        }
        else { }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactionUI.SetActive(false);
        if (MiniGamePanel != null)
            MiniGamePanel.SetActive(false);
        if(interactedObject != null)
        {
        if (interactedObject.GetComponent<ValuesOfMiniGame>() != null)
            interactedObject.GetComponent<ValuesOfMiniGame>().canvas.SetActive(false);  
        }

        canInteract = false;
        Cursor.visible = false; // Fare imlecini gizle
        //Cursor.lockState = CursorLockMode.Locked; // Ýmleci ekranýn ortasýna kilitle
    }

    public void Interact()
    {
        if (interactedObject.name == "MinigameTrigger")
        {
            MiniGamePanel.SetActive(true);
            Cursor.visible = true; // Fare imlecini göster
            Cursor.lockState = CursorLockMode.None; // Ýmlecini kilidini kaldýr
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
