using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {
    private float factor;
    private float size;
	// Use this for initialization
	void Start () {
        StoneSpawner s = FindObjectOfType<StoneSpawner>();
        factor = s.GetPrevAccel();
        float low = Mathf.Max(factor - 0.5f, 0.01f);
        float high = Mathf.Min(factor + 0.5f, 9.99f);
        factor = Random.Range(low, high);
        size = 0.01f;

    }
	
	// Update is called once per frame
	void Update () {
        if (size < factor)
        {
            this.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            size += 0.01f;
            this.transform.position += new Vector3(0, 0.005f, 0);
            this.transform.Rotate(new Vector3(0,1,0));
        }
    }
}
