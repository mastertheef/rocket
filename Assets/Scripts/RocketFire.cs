using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFire : MonoBehaviour {

    [SerializeField] private GameObject ProjectilePrefab;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        }
	}
}
