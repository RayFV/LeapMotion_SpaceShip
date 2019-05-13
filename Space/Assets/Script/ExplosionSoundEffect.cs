using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSoundEffect : MonoBehaviour {

    AudioSource audioData;
    public AudioClip explosionClip;
    public AudioClip hurtClip;
    // Use this for initialization
    void Start () {
        audioData = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	public void PlaySound () {
        audioData.PlayOneShot(explosionClip);
    }

    public void Hurt()
    {
        audioData.PlayOneShot(hurtClip);
    }
}
