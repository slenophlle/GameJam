using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public static List<GameObject> invObjects = new List<GameObject>();
    public ItemData itemData;
    [Header("Images")]
    [SerializeField] Image imageSlot1;
    [SerializeField] Image imageSlot2;
    [SerializeField] Image imageSlot3;

    private static int objLenght = 0;

    private void Start()
    {
        objLenght = 0;
    }

    public void InteractObject(GameObject item)
    {
        invObjects.Add(item);

        objLenght++;
        Debug.Log(gameObject.name + "bulundu. Envanterde " + objLenght + " obje var.");
        gameObject.SetActive(false);


        if (objLenght == 1)
        {
            imageSlot1.sprite = itemData.uiItem;
        }
        if (objLenght == 2)
        {
            imageSlot2.sprite = itemData.uiItem;
        }
        if (objLenght == 3)
        {
            imageSlot3.sprite = itemData.uiItem;
        }
    }
}