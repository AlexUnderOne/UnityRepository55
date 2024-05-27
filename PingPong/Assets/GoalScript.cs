using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public bool isPlayer1Goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
         
            if (isPlayer1Goal == true)
            {
                Debug.Log("Player 1 Scored...");
                GameObject.Find("Game Manager").GetComponent<GameManager>().Player1Scored();
            }
            else
            {
                Debug.Log("Player 2 Scored...");
                GameObject.Find("Game Manager").GetComponent<GameManager>().Player2Scored();
            }
                
            
            
        }
        

    }
}
