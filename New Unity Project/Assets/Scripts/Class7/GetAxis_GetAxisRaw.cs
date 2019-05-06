using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAxis_GetAxisRaw : MonoBehaviour {

    /*
     * Input.GetAxis    Input.GetAxisRaw
     *  返回类型 float
     *      不做任何操作，将会重回原点
     */
    float axisX;
    float axisY;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * Horizontal   Vertical
         *  水平          垂直
         *  输入管理器控制（Input Manager）中
         *      Gravity     返回原点 的 速度
         *      Sensitivity 移动到 -1 或者 1 位置 的速度
         *      Snap        勾选与否，触发 相反 的按键 是否 立即归为 原点，角色控制时勾选
         */

        /*
         * Input.GetAxis
         *  根据坐标轴名称返回虚拟坐标系中的值
         *      键盘和控制器取值范围在-1...1之间
         */
        //axisX = Input.GetAxis("Horizontal");    //水平移动
        //axisY = Input.GetAxis("Vertical");      //垂直移动

        /*
         * Input.GetAxisRaw
         *  通过坐标轴名称返回一个不使用平滑滤波器的虚拟坐标值
         *      键盘和控制器取值范围在-1...1之间
         *      键盘输入必然会是-1、0或1
         */
        axisX = Input.GetAxisRaw("Horizontal");    //水平移动
        axisY = Input.GetAxisRaw("Vertical");      //垂直移动

        this.transform.position = new Vector3(axisX, axisY, 0);
	}
}
