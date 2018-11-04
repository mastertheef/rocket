using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] private GameObject HitEffect;
    private float speed;
    private float maxY = 5.2f;

    private Vector2 targetPosition;

	// Use this for initialization
	void Start () {
        targetPosition = new Vector2(transform.position.x, maxY);
        speed = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        speed += Time.deltaTime * 25;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position.y >= maxY)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            Instantiate(HitEffect, transform.position, HitEffect.transform.rotation);
            Destroy(gameObject);
            collision.GetComponent<Asteroid>().DecreaseLife();
        }
    }
}
