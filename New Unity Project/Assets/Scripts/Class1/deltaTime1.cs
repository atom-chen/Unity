﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deltaTime1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position =
            new Vector3(transform.position.x, transform.position.y + 1.5f * Time.deltaTime, transform.position.z);
	}
}
