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

    public float Remap(float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

public void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].point.x > 6.5)
        {
            Vector3 pos = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, collision.contacts[0].point.z);
            GameObject rip = SpawnRipple(pos);
            rippleSound(rip);
        }

    }

    public GameObject SpawnRipple(Vector3 pos)
    {
        GameObject rip = Instantiate(ripple);
        rip.transform.position = new Vector3(pos.x, -5, pos.z);
        GameObject.Destroy(rip, 10);

        return rip;
    }

    private void rippleSound(GameObject rip)
    {
        StoneSpawner s = FindObjectOfType<StoneSpawner>();
        float accel = s.GetPrevAccel();

        AudioSource bell = rip.GetComponent<AudioSource>();
        float pitch = Remap(accel, 0.01f, 10.0f, 0.01f, 3.0f);
        float low = Mathf.Max(pitch - 0.5f, 0.01f);
        float high = Mathf.Min(pitch + 0.5f, 2.99f);
        bell.pitch = Random.Range((3.0f - high), (3.0f - low));
    }
}
