using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject ufoPrefab;
    [SerializeField] private float minDelay = 0.5f;
    [SerializeField] private float maxDelay = 2f;
    [Range(0, 1)]
    [SerializeField] private float ufoProbability;
    [SerializeField] private float[] asteroidSpeed = { 3f, 6f };


    private float maxLeft = -2.7f;
    private float maxRight = 2.7f;
    private Coroutine spawning;

    private IEnumerator Spawn()
    {
        while (true)
        {
            var random = Random.Range(0f, 1f);
            
            if (ufoProbability > random)
            {
                var position = new Vector2(Random.Range(-1.5f, 1.5f), transform.position.y);
                var ufo = Instantiate(ufoPrefab, position, Quaternion.identity);
                ufo.GetComponent<Ufo>().speed = Random.Range(2f, 4f);
                ufo.GetComponent<Ufo>().sinSpeed = Random.Range(1f, 3f);
            }
            else
            {
                var position = new Vector2(Random.Range(maxLeft, maxRight), transform.position.y);
                var asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);
                asteroid.GetComponent<Asteroid>().speed = Random.Range(asteroidSpeed[0], asteroidSpeed[1]);
            }
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }

    public void StartSpawning()
    {
        spawning = StartCoroutine(Spawn());
    }

    public void StopSpawning()
    {
        if (spawning != null)
        {
            StopCoroutine(spawning);
            spawning = null;
        }
    }
}
