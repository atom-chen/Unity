using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrigger : MonoBehaviour {

    /*
     * other为带有Trigging 的场景物体
     */
    /*private void OnTriggerEnter(Collider other)             //当Collider（碰撞体）进入trigger（触发器）时，立即调用
    {
        Debug.Log("OnTriggerEnter");
        other.transform.position = new Vector3(0, 2, 0);
    }*/

    private void OnTriggerStay(Collider other)              //当碰撞体接触触发器时，OnTriggerStay将会在每一帧被调用，直到两物体相分离时才停止触发
    {
        other.transform.position = new Vector3(0, other.transform.position.y + 0.01f, -6);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
