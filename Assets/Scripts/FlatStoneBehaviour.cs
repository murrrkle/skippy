﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatStoneBehaviour : MonoBehaviour {
    private Rigidbody rb;
    private float decay;
    public StoneSpawner manager;

    private Vector3 lastVelocity;
    private float highestYVel;

    private int baseBounces;
    private int bounces;
    public GameObject ripple;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        ripple = GetComponent<GameObject>();
        decay = 0.9f;
        manager = GameObject.FindObjectOfType<StoneSpawner>();
        lastVelocity = rb.velocity;
        bounces = 100;
        baseBounces = Mathf.FloorToInt(manager.getPrevAccel());
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y != 0)
        {
            lastVelocity = rb.velocity;
        }
        if (Mathf.Abs(rb.velocity.y) > Mathf.Abs(highestYVel))
        {
            highestYVel = rb.velocity.y;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        Debug.Log("Bounce Force: " + Mathf.Abs(rb.velocity.y) + 
            "\nAccel: " + Mathf.Abs(manager.getPrevAccel()) + 
            "\nBase Bounce Value: " + baseBounces +
            "\nHighest Velocity " + highestYVel);
        if (bounces == 100)
        {
            bounces = Mathf.Abs(baseBounces - Mathf.FloorToInt(highestYVel));
        }
        */
        Vector3 pos = collision.transform.position;
        GameObject ps = Instantiate(ripple);
        ps.transform.position = new Vector3(pos.x, -5, pos.y);

        if (bounces == 100)
        {
            float ratio =Mathf.Sqrt(lastVelocity.x * lastVelocity.x + lastVelocity.z + lastVelocity.z)/ Mathf.Abs(lastVelocity.y);
            bounces = Mathf.FloorToInt(ratio);
            Debug.Log(ratio);
        }

        if (collision.gameObject.CompareTag("Surface"))
        {
            float vertVel = Mathf.Abs(lastVelocity.y);
            rb.AddForce(0, vertVel * decay * 50, 0);
            bounces -= 1;


            if (bounces <= 0)
            {
                Object.Destroy(this.gameObject);
            }
        }
    }
}