using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkIt;
using System;
using System.IO;
public class StoneSpawner : MonoBehaviour
{
    public float factor;
    public Rigidbody stonePrefab;
    public Camera c;
    private float prevAccel;
    void Start()
    {
        prevAccel = 0;
    }
    
    public float GetPrevAccel()
    {
        return prevAccel;
    }

    public void Spawn(float power)
    {
        Rigidbody rb = Instantiate(stonePrefab);
        rb.mass = UnityEngine.Random.Range(1.5f, 2.5f);
        rb.transform.SetPositionAndRotation(new Vector3(-1, -0.5f, -1), new Quaternion(0,0,0,0));
        Vector3 vec = factor*power*c.transform.forward;
        Debug.Log(vec);
        rb.AddForce(vec.x, vec.y, vec.z);
    }


    public void NetworkIt_Message(object m)
    {
        Message message = (Message)m;
        if (message.Subject.Equals("Throw"))
        {
            float accel;
            float.TryParse(message.GetField("accel"), out accel);
            if (prevAccel != accel)
                Spawn(accel);
            prevAccel = accel;
        }
    }
}
