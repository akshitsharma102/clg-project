using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    [SerializeField]
    private Rigidbody rb;

    //essential variables for touch controls
    private float screenWidth;
    

    //motion variables
    [SerializeField]
    private float ForwardSpeed = 10f;
    [SerializeField]
    private float LRspeed = 3f;

    //rotation variables
    [SerializeField]
    private float RotationAngle = 45f;
    [SerializeField]
    private float TimeToRotate = 3f;

    //death variabls
    [HideInInspector]
    public bool IsDead = false;
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        screenWidth = Screen.width;

    }
    private void Update()
    {
        if (IsDead == false)
        {
            rb.AddForce(transform.forward * ForwardSpeed * Time.deltaTime);

            int i = 0;

            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).position.x > screenWidth / 2)
                {
                    rb.velocity = new Vector3(1f * LRspeed, rb.velocity.y, rb.velocity.z);
          
                }
                else if (Input.GetTouch(i).position.x < screenWidth / 2)
                {
                    rb.velocity = new Vector3(-1f * LRspeed, rb.velocity.y, rb.velocity.z);
                    
                }
                ++i;
            }
            if (Input.touchCount == 0)
            {
                rb.velocity = new Vector3(0f, 0f, rb.velocity.z);
            }
        }
    }
    private void FixedUpdate()
    {
        if (IsDead == false)
        {
            rb.AddForce(transform.forward * ForwardSpeed * Time.deltaTime);

            int i = 0;

            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).position.x > screenWidth / 2)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 1f * -RotationAngle), TimeToRotate * Time.deltaTime);
                }
                else if (Input.GetTouch(i).position.x < screenWidth / 2)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, -1f * -RotationAngle), TimeToRotate * Time.deltaTime);
                }
                ++i;
            }
            if (Input.touchCount == 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), TimeToRotate * Time.deltaTime);
            }
        }
        
    }
    





}
