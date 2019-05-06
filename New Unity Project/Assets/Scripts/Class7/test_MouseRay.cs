using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_MouseRay : MonoBehaviour {

    public Camera mCamera = null;           //用于获取摄像头

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = mCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(r, out hit, 1000f))
            {
                if (hit.collider.tag == "Cube")
                {
                    Debug.Log("OnMouseDown Clicked $$$$$ 鼠标点击时");
                }
            }
        }
        */

        /*
         * 以上代码
         *  相当于
         * 以下代码
         *      不同处在于 鼠标的点击
         */

        if (!Input.GetMouseButtonDown(0))   //如果 鼠标 左键 没有按下
        {
            return;                         //返回 空
        }

        //ScreenPointToRay      屏幕位置转射线
        //Input.mousePosition   鼠标当前位置
        Ray r = mCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;                     //光线投射的碰撞信息（射线方向末端开始的碰撞）
        if (Physics.Raycast(r, out hit, 1000f))
        {
            if(hit.collider.tag == "Cube")  //判断与射线发生碰撞的对象
            {
                Debug.Log("OnMouseDown Clicked $$$$$ 鼠标点击时");
            }
        }
    }
}
