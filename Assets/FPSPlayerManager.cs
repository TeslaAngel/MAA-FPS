﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerManager : MonoBehaviour
{
    public float WalkingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //GetComponent<Rigidbody>().AddRelativeForce(0, 500*Time.deltaTime, 7000*Time.deltaTime);
            //print(GetComponent<Rigidbody>().velocity);
            transform.Translate(0, 0, WalkingSpeed*Time.deltaTime);
        }
    }
}
