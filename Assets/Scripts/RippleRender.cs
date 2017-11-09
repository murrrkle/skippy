using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleRender : MonoBehaviour {
    public GameObject ripple;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        Vector3 pos = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, collision.contacts[0].point.z);
        /*
        GameObject rip = new GameObject();
        rip.AddComponent<ParticleSystem>();
        rip.transform.position = new Vector3(pos.x, -5, pos.y);
        */

        GameObject rip = Instantiate(ripple);
        rip.transform.position = new Vector3(pos.x, -5, pos.z);
        AudioSource bell = rip.GetComponent<AudioSource>();
        bell.pitch = Random.Range(0.1f, 2.0f);
    }
}
