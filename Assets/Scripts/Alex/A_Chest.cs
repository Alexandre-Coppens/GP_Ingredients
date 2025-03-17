using System.Collections;
using UnityEngine;

public class Chest : Interactive
{
    public KeyItemData data;
    public override void OnInteraction()
    {
        //If I want to do the base OnInteraction anyway first
        //
        //Remove UNLIT_TORCH from inventory
        //In addition, add LIT_TORCH to found objects
        GetComponent<Animator>().SetTrigger("Open");
        Inventory.Instance.PickupKeyItem(data);
    }
}
