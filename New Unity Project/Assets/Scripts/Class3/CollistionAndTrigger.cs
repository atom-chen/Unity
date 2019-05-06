using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollistionAndTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)             //当Collider（碰撞体）进入 trigger（触发器）时调用
    {
        Debug.Log("OnTrigger    Enter");
    }
    private void OnTriggerExit(Collider other)              //当Collider（碰撞体）停止 触发trigger（触发器）时调用
    {
        Debug.Log("OnTrigger    Exit");
    }
    private void OnTriggerStay(Collider other)              //当碰撞体接触触发器时，OnTriggerStay将在每一帧被调用
    {
        Debug.Log("OnTrigger    Stay");
    }

    private void OnCollisionEnter(Collision collision)      //当此Collider/Rigidbody 触发另一个Collider/Rigidbody 时调用
    {
        collision.gameObject.transform.position = new Vector3(0, 5, 0);
        Debug.Log("OnCollision  Enter");
    }
    private void OnCollisionExit(Collision collision)       //当此Collider/Rigidbody 停止 触发另一个Collider/Rigidbody 时调用
    {
        Debug.Log("OnCollision  Exit");
    }
    private void OnCollisionStay(Collision collision)       //当次Collider/Rigidbody 触发另一个Collider/Rigidbody 时，将会在每一帧调用
    {
        Debug.Log("OnCollision  Stay");
    }
}
