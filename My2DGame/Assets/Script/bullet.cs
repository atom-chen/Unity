// 柯博文老師 www.powenko.com
using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity =  new Vector2(10, 0);
		Destroy(gameObject,1.2f);
	}
	

}
