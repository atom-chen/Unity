using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    /*public Transform player;
    public float distanceH = 7f;
    public float distanceV = 4f;

    public float smoothSpeed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        Vector3 nextpos = player.forward * -1 * distanceH + player.up * distanceV + player.position;

        //this.transform.position = nextpos;
        this.transform.position = Vector3.Lerp(this.transform.position, nextpos, smoothSpeed * Time.deltaTime);
        this.transform.LookAt(player);
    }*/

    public Transform target;
    public float relativeHeigth = 30f;
    public float zDistance = 5f;
    public float dampSpeed = 1f;

    void Update()
    {
        Vector3 newPos = target.position + new Vector3(0, relativeHeigth, -zDistance);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);

        this.transform.LookAt(target);
    }
}
