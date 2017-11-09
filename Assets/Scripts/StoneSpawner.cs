using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkIt;
using System;
using System.IO;


/// <summary>
///  Intended for use with the NetworkItClient game object. This class provides an example of how
///  a game object can listen to events on the network.
/// </summary>
public class StoneSpawner : MonoBehaviour
{
    public float factor;
    public Rigidbody stonePrefab;
    public Camera c;
    private float prevAccel;
    void Start()
    {
        //Debug.Log("StoneSpawner initialized.");
        prevAccel = 0;
    }

    public float getPrevAccel()
    {
        return prevAccel;
    }

    public void spawn(float power)
    {
        Rigidbody rb = Instantiate(stonePrefab);
        rb.transform.SetPositionAndRotation(new Vector3(-1, -0.5f, -1), new Quaternion(0,0,0,0));
        Vector3 vec = factor*power*c.transform.forward;
        Debug.Log(vec);
        rb.AddForce(vec.x, vec.y, vec.z);
    }


    public void NetworkIt_Message(object m)
    {
        //TODO your code here
        Message message = (Message)m;
        float accel;
        float.TryParse(message.GetField("accel"), out accel);
        spawn(accel);
        prevAccel = accel;
        

        //int count = 0;
        //int.TryParse(message.GetField("count"), out count);

        //this.transform.rotation = Quaternion.Euler(0, count * 10, 0);
    }

    public void NetworkIt_Connect(object args)
    {
        //TODO your code here
        EventArgs eventArgs = (EventArgs)args;
    }

    public void NetworkIt_Disconnect(object args)
    {
        //TODO your code here
        EventArgs eventArgs = (EventArgs)args;
    }

    public void NetworkIt_Error(object err)
    {
        //TODO your code here
        ErrorEventArgs error = (ErrorEventArgs)err;
        Debug.LogError(error);
    }
}
