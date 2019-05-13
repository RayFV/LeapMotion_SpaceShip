using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float deathLine;
    public float speed;
    
    public float hp = 0.1f;
    public Transform explosionPrefab;
    public ExplosionSoundEffect explosionSound;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed);
        if (transform.position.z < deathLine)
        {
            Destroy(this.gameObject);
        }
    }


    public void LaserHit()
    {
        hp -= Time.deltaTime;
        if (hp <= 0)
        {
            
            Transform obj = Instantiate(explosionPrefab,transform.position, Quaternion.identity);
            Data.score += 10;
            Destroy(gameObject);
            explosionSound.PlaySound();
        }
    }
    public void RocketHit()
    {
        Transform obj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Data.score += 10;
        Destroy(gameObject);
        explosionSound.PlaySound();
    }
    
}
