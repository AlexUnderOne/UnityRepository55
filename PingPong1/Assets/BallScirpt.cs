using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScirpt : MonoBehaviour
{
    public float speed = 7f;
    public float addSpeed = 0.1f;

    public Rigidbody2D rb;
    

    public Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
       
        Launch();

    }



    public void Reset()
    {
        speed = 7f;
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerTag") && speed <=25)
        {


            rb.AddForce(transform.right / 100);
            //rb.velocity = Vector2.ClampMagnitude(rb.velocity , speed + addSpeed);

            Debug.Log("Impact from Player");
           
            
            
        }
        else if (other.gameObject.CompareTag("PlayerTag2"))
        {
            rb.AddForce(-transform.right / 100);
            Debug.Log("Impact from Player2");
        }
        
        

    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }
    

}