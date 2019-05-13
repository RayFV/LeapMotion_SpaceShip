using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

    public Transform asteroidPoint;
    public GameObject[] asteroids;

    public float idleTime;
    public float range;
    public float asteroidDeathLine = -7;
    public float asteroidSpeed = 0.1f;

    public Transform[] explosionPrefabs;

    public ExplosionSoundEffect explosionSound;

    float repeatRate = 40f;


    void Start ()
    {
        StartCoroutine(CreateAsteroid());
        InvokeRepeating("IncreaseDifficult", 60f, repeatRate);
    }

    IEnumerator CreateAsteroid()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            GameObject asteroid = Instantiate(asteroids[Random.Range(0, asteroids.Length)]);
            asteroid.name = "Asteroid";
            asteroid.tag = "Asteroid";
            asteroid.transform.position = asteroidPoint.position + ((Vector3)Random.insideUnitCircle * range);
            asteroid.AddComponent<Asteroid>().explosionPrefab = explosionPrefabs[Random.Range(0, explosionPrefabs.Length)];
            asteroid.GetComponent<Asteroid>().deathLine = asteroidDeathLine;
            asteroid.GetComponent<Asteroid>().speed = asteroidSpeed;
            asteroid.GetComponent<Asteroid>().explosionSound = explosionSound;

            MeshCollider collider = asteroid.AddComponent<MeshCollider>();
            collider.convex = true;
            collider.isTrigger = true;

            yield return new WaitForSeconds(idleTime);
        }
    }

    void IncreaseDifficult()
    {
        idleTime -= 0.1f;
        asteroidSpeed += 0.02f;
    }
}
