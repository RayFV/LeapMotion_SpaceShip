using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

[System.Serializable]
public struct Boundary
{
    public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public struct Speed
{
    public float x, y;
}

public class Player : MonoBehaviour {

    public Speed speed;
    public Boundary boundary;

    public RigidHand handL;
    public Transform fighterL;
    public RigidFinger[] fingersL;

    public RigidHand handR;
    public Transform fighterR;
    public RigidFinger[] fingersR;

   

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Move(handL, fighterL);
        Move(handR, fighterR);
        Fire(fighterR, fingersR);
        FireRocket(fighterL, fingersL);
    }

    private float FixBoundary(float value, float min,float max)
    {
        if (value < min)
            value = min;
        else if (value > max)
            value = max;

        return value;
    }

    void Move(RigidHand hand, Transform fighter)
    {
        if (hand.gameObject.activeSelf)
        {
            fighter.gameObject.SetActive(true);
            Vector3 handPosition = hand.GetPalmPosition();

            Quaternion tmp = fighter.rotation;
            tmp.z = -hand.GetPalmRotation().x;
            fighter.rotation = tmp;

            float newX = fighter.position.x - tmp.z * speed.x;
            float newY = handPosition.y * speed.y;

            newX = FixBoundary(newX, boundary.xMin, boundary.xMax);
            newY = FixBoundary(newY, boundary.yMin, boundary.yMax);

            fighter.position = new Vector3(newX, newY, fighter.position.z);

        }
        else
        {
            fighter.gameObject.SetActive(false);
        }

    }

    void Fire(Transform fighter, RigidFinger[] fingers)
    {
        float fingerData = 0.0f;
        foreach (RigidFinger finger in fingers)
        {
            fingerData += finger.GetFingerJointStretchMecanim(1);
        }
        if (fingerData < -240f)
        {
            fighter.GetComponent<Drone>().Fire(true);
        }
        else
        {
            fighter.GetComponent<Drone>().Fire(false);
        }
    }

    void FireRocket(Transform fighter, RigidFinger[] fingers)
    {
        float fingerData = 0.0f;
        foreach (RigidFinger finger in fingers)
        {
            fingerData += finger.GetFingerJointStretchMecanim(1);
        }
        if (fingerData < -240f)
        {
            fighter.GetChild(0).GetComponent<RocketLauncher>().Launch();
        }
        else
        {
            fighter.GetChild(0).GetComponent<RocketLauncher>().energyBar.ChangeStatus(true);
        }
    }
}
