// 柯博文老師  www.powenko.com
using UnityEngine;
using System.Collections;

public class MyControl : MonoBehaviour {
	/*
	public  AnimationClip Walk;
	public float WalkSpeed=3.0f;
	public  AnimationClip Run;
*/
	
	// Update is called once per frame
	void Update () {
		/*
		float Speed;
		Speed=WalkSpeed;
	*/
		/*
		float WalkSpeed=1.0f;
		float x=Input.GetAxis("Vertical")*WalkSpeed*Time.deltaTime;
		float y=Input.GetAxis("Horizontal")*WalkSpeed*Time.deltaTime;
		Vector3 t1=gameObject.transform.position;
		t1.x=t1.x+x;
		t1.z=t1.z+y;

		gameObject.transform.position=t1;
*/

		if (Input.GetButton("Jump")) {
			GetComponent<Animation>().CrossFade ("Attack");
		}else if (Input.GetButton("Fire1")) {

			GetComponent<Animation>().CrossFade ("Jump");
		}else{

		   if (Input.GetAxis("Vertical") > 0.2f){
		    	GetComponent<Animation>().CrossFade ("Walk");
		   }else{
		    	GetComponent<Animation>().CrossFade ("idle");
		   }
		}
	
	}
}
