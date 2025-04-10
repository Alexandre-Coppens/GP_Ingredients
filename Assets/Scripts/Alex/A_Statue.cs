using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Statue : Interactive
{
    public enum Skins
    {
        F_Druid,
        F_Peasant_1,
        F_Witch,
        M_Bard,
        M_King,
        M_Rogue,

    }

  //   public Skins skin;
   // [SerializeField] private bool changeSkin;

    private GameObject[] statueSkins;
    private byte skinNum = 1;
    public KeyItemData data;
    public GameObject torch;

    private void Start()
    {
        SkinnedMeshRenderer[] meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
        statueSkins = GetFromTo(meshes, 0, 6);
        ChangeSkin((Skins)0);
    }

    public override void OnInteraction()
    {
        //If I want to do the base OnInteraction anyway first
        //Remove UNLIT_TORCH from inventory
        //In addition, add LIT_TORCH to found objects
        GetComponent<Animator>().SetTrigger("Open");
        ChangeSkin((Skins)skinNum);
        torch.GetComponent<WallTorch_Baptiste>().ChangeTorch(skinNum);
        skinNum++;
        if (skinNum >= 6) { skinNum = 0; }
        //Inventory.Instance.PickupKeyItem(data);
    }

    //private void Update()
    //{
    //    if (changeSkin)
    //    {
    //        ChangeSkin((Skins)skinNum);
    //        //changeSkin = false;
    //    }
    //}

    private void ChangeSkin(Skins newSkin)
    {
        foreach (GameObject statue in statueSkins) { statue.SetActive(false); }
        statueSkins[(byte)newSkin].SetActive(true);
    }

    private GameObject[] GetFromTo(SkinnedMeshRenderer[] array, int start,  int end)
    {
        List<GameObject> r = new();
        for (int i = start; i < end; i++) { r.Add(array[i].GameObject()); }
        return r.ToArray();
    }
}