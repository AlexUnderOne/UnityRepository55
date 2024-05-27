using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cemafor : MonoBehaviour
{
    public SpriteRenderer spriteRendererForCemafor;
    public float timerCemafor;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (timerCemafor > 10)
        //{
        //    spriteRendererForCemafor.color = Color.red;
        //}
        //else if(timerCemafor > 5)
        //{
        //    spriteRendererForCemafor.color = Color.green;
        //}
        //else
        //{
        //    spriteRendererForCemafor.color = Color.yellow;
        //}


        timerCemafor += Time.deltaTime * 5;
        if (timerCemafor > 10) timerCemafor = 0;

        //if (timerCemafor > 7)
        //{
        //    spriteRendererForCemafor.color = Color.red;
        //}
        //else if(timerCemafor > 5) 
        //{
        //    spriteRendererForCemafor.color = Color.yellow;
        //}
        //else
        //{
        //    spriteRendererForCemafor.color = Color.green;
        //} 
        switch ((int) timerCemafor)
        {
            case (0):
                spriteRendererForCemafor.color = Color.green;
                break;
            case (3):
                spriteRendererForCemafor.color = Color.yellow;
                break;
            case (7):
                spriteRendererForCemafor.color = Color.red;
                break;


            default:
                break;

        }
    }
}
