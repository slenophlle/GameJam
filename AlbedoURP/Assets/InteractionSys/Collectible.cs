using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public static List<GameObject> invObjects = new List<GameObject>();
    public ItemData itemData;

    [Header("Images")]
    [SerializeField] Image imageSlot1;  // ScrewDriver için
    [SerializeField] Image imageSlot2;  // SampleTube için
    [SerializeField] Image imageSlot3;  // IDCard için

    public static bool isIDTrigged = false;  // IDCard alýndý mý kontrolü için

    private void Start()
    {
        // Baþlangýçta obje sýfýrlamasý veya baþka iþlemler yapýlabilir
    }

    public void InteractObject(GameObject item)
    {
        invObjects.Add(item);  // Alýnan objeyi envantere ekle

        Debug.Log(gameObject.name + " bulundu. Envantere eklendi.");
        gameObject.SetActive(false);  // Obje alýndýktan sonra sahneden kaldýr

        // Objenin tag'ine göre envanterdeki uygun slotu doldur
        if (item.CompareTag("ScrewDriver"))
        {
            imageSlot1.sprite = itemData.uiItem;
            Debug.Log(itemData.hasIdcard);// ScrewDriver imageSlot1'e
        }
        else if (item.CompareTag("SampleTube"))
        {
            imageSlot2.sprite = itemData.uiItem;  // SampleTube imageSlot2'ye
        }
        else if (item.CompareTag("IDcard"))
        {
            imageSlot3.sprite = itemData.uiItem;  // IDCard imageSlot3'e
            isIDTrigged = itemData.hasIdcard;
        }
    }
}
