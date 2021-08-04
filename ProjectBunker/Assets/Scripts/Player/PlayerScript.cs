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
    [HideInInspector]
    public bool IsDead = false;

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
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        screenWidth = Screen.width;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead == false)
        {
            MoveCharacterForward();
            int i = 0;

            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).position.x > screenWidth / 2)
                {
                    //moving right
                    MoveCharacter(1.0f);
                }
                else if (Input.GetTouch(i).position.x < screenWidth / 2)
                {
                    //moving left
                    MoveCharacter(-1.0f);
                }
                ++i;
            }
            if (Input.touchCount == 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), TimeToRotate * Time.deltaTime);
            }
        }
    }
    private void MoveCharacterForward()
    {
        rb.AddForce(new Vector3( 0, 0, ForwardSpeed * Time.deltaTime));
    }
    private void MoveCharacter(float horizontalInput)
    {
        rb.AddForce(new Vector3(horizontalInput * LRspeed * Time.deltaTime, 0, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, horizontalInput * -RotationAngle), TimeToRotate * Time.deltaTime);
    }





}
