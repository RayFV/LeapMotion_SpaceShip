using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

    public float lifeTime;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void Update ()
	{

		if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
		   Destroy(transform.gameObject);
	
	}
}
