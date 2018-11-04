using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollision : MonoBehaviour {

    [SerializeField] private GameObject ExplosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            var explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Camera.main.GetComponent<CameraShake>().Shake(1f);
            gameObject.SetActive(false);
            
        }

        if (collision.tag == "Ufo")
        {
            GameManager.Instance.AddScore(1);
            Destroy(collision.gameObject);
        }
    }
}
