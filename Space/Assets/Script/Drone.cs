using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Drone : MonoBehaviour
{

    private bool fire;

    public GameObject laser;
    public EnergyBar energyBar;

    AudioSource audioData;

    public AudioClip laserStartSound;
    public AudioClip laserFireSound;
    public AudioClip laserEndSound;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (fire)
        {
            if (!energyBar.IsEmpty())
            {
                Ray ray = new Ray(transform.position, Vector3.forward);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.name == "Asteroid")
                    {
                        hit.transform.GetComponent<Asteroid>().LaserHit();
                    }
                }
                energyBar.ChangeStatus(false);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.green);
            }
            
        }
        else
        {
            energyBar.ChangeStatus(true);
        }
    }

    public void Fire(bool flag)
    {
        if (fire != flag && gameObject.activeSelf)
        {
            if (flag && !energyBar.IsEmpty())
            {
                StartCoroutine(StartSoundEffect());
                laser.SetActive(true);
            }
            else
            {
                laser.SetActive(false);
                EndSoundEffect();
                StopAllCoroutines();
            }
        }

        if (energyBar.IsEmpty())
        {
            laser.SetActive(false);
            EndSoundEffect();
            StopAllCoroutines();
        }
        fire = flag;
    }

    IEnumerator StartSoundEffect()
    {
        audioData.clip = laserStartSound;
        audioData.Play();
        yield return new WaitForSeconds(audioData.clip.length);
        audioData.clip = laserFireSound;
        audioData.loop = true;
        audioData.Play();
    }

    void EndSoundEffect()
    {
        audioData.clip = laserEndSound;
        audioData.loop = false;
        audioData.Play();
    }

    private void OnDisable()
    {
        audioData.Stop();
    }
}
