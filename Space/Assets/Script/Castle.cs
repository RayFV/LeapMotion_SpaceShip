using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {

    public EnergyBar hp;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Asteroid")
        {
            hp.FixedValue(-10);
            other.gameObject.GetComponent<Asteroid>().explosionSound.Hurt();
            Destroy(other.gameObject);

            if (hp.IsEmpty())
                Gameover();
        }
    }

    private void Gameover()
    {
        GameManager.instance.GameOver();
    }


}
