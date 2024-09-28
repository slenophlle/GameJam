using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public static List<GameObject> invObjects = new List<GameObject>();
    public ItemData itemData;

    [Header("Images")]
    [SerializeField] Image imageSlot1;  // ScrewDriver i�in
    [SerializeField] Image imageSlot2;  // SampleTube i�in
    [SerializeField] Image imageSlot3;  // IDCard i�in

    public static bool isIDTrigged = false;  // IDCard al�nd� m� kontrol� i�in

    private void Start()
    {
        // Ba�lang��ta obje s�f�rlamas� veya ba�ka i�lemler yap�labilir
    }

    public void InteractObject(GameObject item)
    {
        invObjects.Add(item);  // Al�nan objeyi envantere ekle

        Debug.Log(gameObject.name + " bulundu. Envantere eklendi.");
        gameObject.SetActive(false);  // Obje al�nd�ktan sonra sahneden kald�r

        // Objenin tag'ine g�re envanterdeki uygun slotu doldur
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
