using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo: MonoBehaviour {

    public float speed = 5f;
    public float sinSpeed = 1f;
    public float minY = -6f;
    public GameObject CollectEffectPrefab;

    private int[] directionModifiers = new int[2] { -1, 1 };
    private int directionModifier;
    private Vector3 startPosition, targetPos;

    // Use this for initialization
    void Start () {
        targetPos = transform.position;
        directionModifier = directionModifiers[Random.Range(0, 2)];
    }

    void Update () {
        targetPos = transform.position;
        targetPos.x += directionModifier * Mathf.Sin(Time.time) * Time.deltaTime * sinSpeed;
        targetPos.y -= speed * Time.deltaTime;
        transform.position = targetPos;

        if (transform.position.y <= minY)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(CollectEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
