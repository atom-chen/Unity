using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_OnMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //当 鼠标进入到 GUIElement（GUI元素）或Collider（碰撞提）中时调用
    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter Clicked ~~~~~ 鼠标进入到");
    }

    //当 鼠标移出 GUIElement(GUI元素)或Collider(碰撞体)上时调用
    private void OnMouseExit()
    {
        Debug.Log("OnMouseExit Clicked !!!!! 鼠标移出");
    }

    //当 用户鼠标 拖拽 GUIElement(GUI元素)或Collider(碰撞体)时调用
    private void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag Clicked @@@@@ 鼠标拖拽");
    }

    //当用户 释放鼠标 按钮时调用
    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp Clicked ##### 释放鼠标");
    }

    //当 鼠标在GUIElement(GUI元素)或Collider(碰撞体)上 点击时 调用OnMouseDown
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown Clicked $$$$$ 鼠标点击时");

        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 10f, ForceMode.Impulse);
    }

    //当 鼠标悬浮 在GUIElement(GUI元素)或Collider(碰撞体)上时调用
    private void OnMouseOver()
    {
        Debug.Log("OnMouseOver Clicked %%%%% 鼠标悬浮");
    }
}
