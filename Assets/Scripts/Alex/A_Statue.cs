using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Statue : Interactive
{
    private enum Skins
    {
        F_Druid,
        F_Gypsy,
        F_Peasant_1,
        F_Peasant_2,
        F_Queen,
        F_Witch,
        M_Bard,
        M_King,
        M_Peasant,
        M_Rogue,
        M_Sorcerer,
        M_Wizard
    }

    [SerializeField] private Skins skin;
    [SerializeField] private bool changeSkin;

    private GameObject[] statueSkins;

    public KeyItemData data;

    private void Start()
    {
        SkinnedMeshRenderer[] meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
        statueSkins = GetFromTo(meshes, 0, 12);
        ChangeSkin(Skins.F_Druid);
    }

    public override void OnInteraction()
    {
        //If I want to do the base OnInteraction anyway first
        //
        //Remove UNLIT_TORCH from inventory
        //In addition, add LIT_TORCH to found objects
        GetComponent<Animator>().SetTrigger("Open");
        Inventory.Instance.PickupKeyItem(data);
    }

    private void Update()
    {
        if (changeSkin)
        {
            ChangeSkin(skin);
            changeSkin = false;
        }
    }

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