﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour {

    Quaternion rotation;
    Vector3 position;
    void Awake()
    {
        rotation = transform.rotation;
        position = transform.position;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
        transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
    }
}
