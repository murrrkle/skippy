using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkIt;

public class FlatStoneBehaviour : MonoBehaviour {
    private Rigidbody rb;
    private float decay;
    public StoneSpawner stoneManager;
    public FlowerSpawner flowerManager;

    private Vector3 lastVelocity;
    private float highestYVel;
    
    private int bounces;
	void Start () {
        rb = GetComponent<Rigidbody>();
        decay = 0.95f;
        stoneManager = GameObject.FindObjectOfType<StoneSpawner>();
        flowerManager = GameObject.FindObjectOfType<FlowerSpawner>();
        lastVelocity = rb.velocity;
        bounces = 100;
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
        
        if (collision.contacts[0].point.x > 6.5)
        {
            Object.Destroy(this.gameObject, 10);
        }

        if (bounces == 100)
        {
            float ratio =Mathf.Sqrt(lastVelocity.x * lastVelocity.x + lastVelocity.z + lastVelocity.z)/ Mathf.Abs(lastVelocity.y);
            if (ratio > 6)
            {
                bounces = 5;
            } else
            {
                bounces = Mathf.FloorToInt(ratio);
            }
            Debug.Log(ratio);
        }

        if (collision.gameObject.CompareTag("Surface") && collision.contacts[0].point.x > 6.5)
        {
            float vertVel = Mathf.Abs(lastVelocity.y);
            rb.AddForce(0, vertVel * decay * 70, 0);
            bounces -= 1;


            NetworkItClient client = FindObjectOfType<NetworkItClient>();
            Message m = new Message("Vibrate");
            m.AddField("bounce", "" + bounces);
            client.SendMessage(m);

            if (bounces <= 0 || vertVel < 0.05 )
            {
                Object.Destroy(this.gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        flowerManager.SpawnFlower(this.gameObject.transform.position);
    }
}
