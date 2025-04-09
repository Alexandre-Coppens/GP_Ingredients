using System.Collections;
using UnityEngine;

public class Hand : Interactive
{
    public KeyItemData inHandItem;
    public KeyItemData[] possibleItems;
    public override void OnInteraction()
    {
        KeyItemData newItem = null;
        foreach (KeyItemData item in possibleItems)
        {
            if (Inventory.Instance.IsItemFound(item))
            {
                newItem = inHandItem;
                Inventory.Instance.RemoveFromInventory(item);
                break;
            }
        }
        Inventory.Instance.PickupKeyItem(inHandItem);
        inHandItem = newItem;
    }
}
