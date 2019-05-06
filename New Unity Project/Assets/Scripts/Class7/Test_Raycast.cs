using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Raycast : MonoBehaviour {

    /*
     * Raycast  光线投射
     *  返回类型 bool
     */

    public float rayDistance = 5f;      //射线的长度

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray testRay = new Ray(transform.position, Vector3.down);        //射线 （物体当前位置，方向）
        RaycastHit hitInfomation;       //光线投射的碰撞信息（射线方向末端开始的碰撞）
        
        if (Physics.Raycast(testRay, out hitInfomation, rayDistance))   //（射线，相当于判断射线是否发生碰撞，射线的长度）
        {
            if(hitInfomation.collider.tag == "Environment")             //判断与射线发生碰撞的对象
            {
                SlowDown();             //调用方法
            }
        }

        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);
	}

    void SlowDown()
    {
        transform.localScale = new Vector3(2, 2, 2);
        GetComponent<Rigidbody>().drag = 8f;
    }

    private void OnCollisionEnter(Collision collision)                   //如果当前物体发生碰撞
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
