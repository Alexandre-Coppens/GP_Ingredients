using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class WallTorch_Baptiste : MonoBehaviour
{
    [SerializeField] int correctAnswer;
    [SerializeField] int correctStatue1;
    [SerializeField] int correctStatue2;
    [SerializeField] int correctStatue3;

    private static int numOfCorrect;
    private bool correctFound = false;
   [SerializeField]  GameObject doorLeft;
    [SerializeField]  GameObject doorRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (numOfCorrect == 4) { doorLeft.GetComponent<Animator>().SetTrigger("Open"); doorRight.GetComponent<Animator>().SetTrigger("Open"); }
       
    }

    public void ChangeTorch(int statueNumber) 
    {
       if (statueNumber == correctAnswer)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            correctFound = true;
            numOfCorrect++;
            


        }
        else if (statueNumber == correctStatue1 || statueNumber == correctStatue2 || statueNumber == correctStatue3)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
            if (correctFound == true) { numOfCorrect--; correctFound = false; }
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            if (correctFound == true) { numOfCorrect--; correctFound = false; }
        }
    }
}
