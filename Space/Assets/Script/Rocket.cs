using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public float lifeTime;
    public Vector3 vector;

    [Header("可攻擊目標")]
    public string targetName;


    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(vector);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name ==targetName)
        {
            other.gameObject.GetComponent<Asteroid>().RocketHit();
            Destroy(this.gameObject);
        }

    }


}
