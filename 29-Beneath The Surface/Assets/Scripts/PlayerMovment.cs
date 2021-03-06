﻿using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {

    public float MoveForce = 0.1f;
    public float RotateSpeed = 1f;
    public float MaxLeftAngle = 275f;
    public float MaxRightAngle = 75f;
    public float DistanceTraveled = 0f;
    public Vector3 LastPosition;

	void Start ()
	{
	    LastPosition = transform.position;
	}

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.Rotate(0, 0,RotateSpeed);
            rigidbody2D.AddForce(Vector2.right * MoveForce);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.Rotate(0, 0, -RotateSpeed);
            rigidbody2D.AddForce(-Vector2.right * MoveForce);
        }

        foreach(var i in Input.touches)
        {
            if (i.phase == TouchPhase.Stationary || i.phase == TouchPhase.Moved)
            {
                if (i.position.x < Screen.width/2)
                {
                    transform.Rotate(0, 0, -RotateSpeed);
                    rigidbody2D.AddForce(-Vector2.right * MoveForce);
                }
                else
                {
                    transform.Rotate(0, 0, RotateSpeed);
                    rigidbody2D.AddForce(Vector2.right * MoveForce);
                }
            }
        }
    }

    void FixedUpdate()
    {
        var Dist = LastPosition.y - transform.position.y;
        LastPosition = transform.position;

        DistanceTraveled += Dist;

        if (transform.eulerAngles.z > MaxRightAngle && transform.eulerAngles.z < MaxLeftAngle)
        {

            if (transform.eulerAngles.z - MaxLeftAngle > MaxRightAngle - transform.eulerAngles.z)
            {
                transform.eulerAngles = new Vector3(0, 0, MaxLeftAngle);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, MaxRightAngle);
            }

            
        }
    }
}
