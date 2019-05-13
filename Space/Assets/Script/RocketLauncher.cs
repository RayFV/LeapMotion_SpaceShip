using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RocketLauncher : MonoBehaviour {

    public GameObject rocket;
    public EnergyBar energyBar;
    public Transform[] launcherTrans;

    AudioSource audioData;

    public AudioClip rocketLaunchSound;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    public void Launch()
    {
        if (energyBar.IsFull())
        {
            foreach(var trans in launcherTrans)
            {
                Instantiate(rocket, trans.position, new Quaternion());
            }
            audioData.PlayOneShot(rocketLaunchSound);
            energyBar.ConsumeAllEnergy();
        }
    }
}
