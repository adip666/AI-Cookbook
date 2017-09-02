using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour {

    public GameObject target;
    protected Agent agent;

    //public float maxSpeed, maxAccel, maxRotation, MaxAngularAccel;



    public virtual void Awake()
    {
        agent = gameObject.GetComponent<Agent>();
    }
    public virtual void Update()
    {
        agent.SetSteering(GetSteering());
    }
    public virtual Steering GetSteering()
    {
        return new Steering();
    }
    public float MapToRange(float rotation)
    {
        rotation %= 360f;

        if (Mathf.Abs(rotation) > 180)
        {
            if (rotation < 0f)
            {
                rotation += 360;

            }else
            {
                rotation -= 360f;
            }
        }
        return rotation;

    }

    public Vector3 OriToVec(float orientation)
    {
        Vector3 vector = Vector3.zero;
        vector.x = Mathf.Sin(orientation * Mathf.Deg2Rad) * 1f;
        vector.z = Mathf.Cos(orientation * Mathf.Deg2Rad) * 1f;
        return vector.normalized;
    }
}
