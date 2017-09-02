﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

	public float maxSpeed;
	public float maxAccel;
	public float orientation;
	public float rotation;
    public Vector3 velocity;
    protected Steering steering;

    public float maxRotation, MaxAngularAccel;


    void Start () {
        velocity = Vector3.zero;
        steering = new Steering();
	}
	
	public void SetSteering(Steering steering)
    {
        this.steering = steering;
    }
    public virtual void Update()
    {
        Vector3 displacement = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;
        // limit orientacji 0-360
        if(orientation< 0.0f)
        {
            orientation += 360f;
        }else if (orientation > 360f)
        {
            orientation -= 360f;
        }
        transform.Translate(displacement, Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up, orientation);
    }
    public virtual void LateUpdate()
    {
        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;
        if(velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }
        if (rotation > maxRotation) // dopisałem to bo było w drugim projekcie
        {
            rotation = maxRotation;
        }
        if (steering.angular == 0f)
        {
            rotation = 0f;
        }
        if(steering.linear.sqrMagnitude == 0f)
        {
            velocity = Vector3.zero;
        }
        steering = new Steering();
    }
}
