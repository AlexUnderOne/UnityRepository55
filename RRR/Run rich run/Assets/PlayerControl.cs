using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 0.5f;
    private Vector3 moveVector3;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();
        
    }
    void MovePlayer()
    {
        moveVector3.x = Input.GetAxis("Horizontal");
        moveVector3.z = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector3 * speed * Time.deltaTime);
    }
    
}
