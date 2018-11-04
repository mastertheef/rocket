using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    [SerializeField] private GameObject Explosion;
    public int lifes = 3;
    public float speed = 5f;
    float rotationSpeed = 2f;
    float minY = -6f;

    private Vector2 targetPos;
    private float rotation;

	// Use this for initialization
	void Start () {
        targetPos = new Vector2(transform.position.x, transform.position.y - 20);
        rotation =  Random.Range(-180, 180);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        transform.Rotate(0, 0, rotation * rotationSpeed * Time.deltaTime);

        if (transform.position.y <= minY)
        {
            Destroy(gameObject);
        }
    }

    public void DecreaseLife()
    {
        lifes--;
        if (lifes == 0)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Camera.main.GetComponent<CameraShake>().Shake(0.1f);
        }
    }
}
