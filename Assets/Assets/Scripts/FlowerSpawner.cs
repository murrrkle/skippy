using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour {
    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject flower4;
    public GameObject flower5;

    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    public AudioClip audio4;
    public AudioClip audio5;

    public AudioClip audio6;
    public AudioClip audio7;
    public AudioClip audio8;
    public AudioClip audio9;
    public AudioClip audio10;

    public GameObject ripple;

    public void SpawnFlower(Vector3 position)
    {
        if (position.x >= 6.5f)
        {
            int flowerType = Random.Range(1, 5);
            GameObject flower;
            int rotationFactor = Random.Range(0, 360);
            StoneSpawner s = FindObjectOfType<StoneSpawner>();
            AudioSource floweraudio = new AudioSource();
            float factor = s.GetPrevAccel();
            switch (flowerType)
            {
                case 1:
                    flower = Instantiate(flower1, position, Quaternion.Euler(0, rotationFactor, 0));
                    floweraudio = flower.AddComponent<AudioSource>();
                    floweraudio.loop = true;
                    floweraudio.spatialBlend = 1.0f;
                    if (factor > 5)
                        floweraudio.clip = audio1;
                    else
                        floweraudio.clip = audio6;
                    break;
                case 2:
                    flower = Instantiate(flower2, position, Quaternion.Euler(0, rotationFactor, 0));
                    floweraudio = flower.AddComponent<AudioSource>();
                    floweraudio.loop = true;
                    floweraudio.spatialBlend = 1.0f;
                    if (factor > 5)
                        floweraudio.clip = audio2;
                    else
                        floweraudio.clip = audio7;
                    break;
                case 3:
                    flower = Instantiate(flower3, position, Quaternion.Euler(0, rotationFactor, 0));
                    floweraudio = flower.AddComponent<AudioSource>();
                    floweraudio.loop = true;
                    floweraudio.spatialBlend = 1.0f;
                    if (factor > 5)
                        floweraudio.clip = audio3;
                    else
                        floweraudio.clip = audio8;
                    break;
                case 4:
                    flower = Instantiate(flower4, position, Quaternion.Euler(0, rotationFactor, 0));
                    floweraudio = flower.AddComponent<AudioSource>();
                    floweraudio.loop = true;
                    floweraudio.spatialBlend = 1.0f;
                    if (factor > 5)
                        floweraudio.clip = audio4;
                    else
                        floweraudio.clip = audio9;
                    break;
                case 5:
                    flower = Instantiate(flower5, position, Quaternion.Euler(0, rotationFactor, 0));
                    floweraudio = flower.AddComponent<AudioSource>();
                    floweraudio.loop = true;
                    floweraudio.spatialBlend = 1.0f;
                    if (factor > 5)
                        floweraudio.clip = audio5;
                    else
                        floweraudio.clip = audio10;
                    break;
                default:
                    flower = Instantiate(flower1, position, Quaternion.Euler(0, rotationFactor, 0));
                    break;
            }
            floweraudio.Play();
            flower.GetComponent<AudioSource>().volume = Remap(factor, 0.01f, 10.0f, 0.1f, 1.0f);

            AudioSource a = ripple.GetComponent<AudioSource>();
            a.playOnAwake = false;
            GameObject rip = Instantiate(ripple);
            ParticleSystem ps = rip.GetComponent<ParticleSystem>();
            var main = ps.main;
            main.loop = true;
            rip.transform.position = new Vector3(flower.transform.position.x, -5, flower.transform.position.z);
            a.playOnAwake = true;
        }
    }
    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
