using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactive
{
    public override void OnInteraction()
    {
        //If I want to do the base OnInteraction anyway first
        //
        //Remove UNLIT_TORCH from inventory
        //In addition, add LIT_TORCH to found objects
        GetComponent<Animator>().SetTrigger("Open");
        StartCoroutine(WaitFor());
    }

    private IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(1);
        ScenesHandler.NextScene();
    }
}
