using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Collectible/Item")]

public class ItemData : ScriptableObject
{
    [Header("INFO")]
    public new string name;
    public Sprite uiItem;

}

