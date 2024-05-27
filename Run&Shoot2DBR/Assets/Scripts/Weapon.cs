using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] float rotationSpeed;
    //SpriteRenderer spriteRendererWeapon = null;
    //Transform transformWeapon = null;
    public float offset;
    private SpriteRenderer spriteRender;



    public void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        //transformWeapon = this.transform;
        //spriteRendererWeapon = GetComponent<SpriteRenderer>();
        //transformWeapon = GetComponent<Transform>();

    }
    public void Update()
    {
        RotationPlayer();
        GunRotation();


    }
    public void RotationPlayer()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float AngleDirection = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion cameraRotation = Quaternion.AngleAxis(AngleDirection, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, rotationSpeed * Time.deltaTime);
    }
    //void RotateWeapon()
    //{
    //    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    if (mousePosition.x < transformWeapon.position.x)
    //    {
    //        spriteRendererWeapon.flipX = false;
    //    }
    //    else
    //        spriteRendererWeapon.flipX = true;

    //}
    void GunRotation()
    {
        // Gun Rotation Function
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (rotZ < 89 && rotZ > -89)
        {
            
            spriteRender.flipY = false;
        }
        else
        {
            
            spriteRender.flipY = true;
        }
    }
}


    


