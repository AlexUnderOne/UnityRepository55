using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float minX , maxX , minY, maxY;
    [SerializeField]  Transform cameraTarget;
    [SerializeField] float followSpeed;
    Animator animationCamera;
    public static CameraFollow instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        animationCamera = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (!cameraTarget) return;
        
        transform.position = Vector3.Lerp
            (transform.position,
            new Vector3(Mathf.Clamp(cameraTarget.position.x, minX, maxX), Mathf.Clamp(cameraTarget.position.y, minY, maxY), -50),
            followSpeed * Time.fixedDeltaTime);
        //new Vector3(Mathf.Clamp(cameraTarget.position.x, minX, maxX), Mathf.Clamp(cameraTarget.position.y, minY, maxY), -10);
    }

    public void cameraShake()
    {
        animationCamera.Play("CameraShake");
    }
}
