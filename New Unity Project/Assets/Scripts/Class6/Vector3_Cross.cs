using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_Cross : MonoBehaviour {

    /*
     * Cross
     *  叉积，向量积，向量乘积
     *      结果 ——> 向量
     */

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cross = Vector3.Cross(transform.position, Vector3.up);
        //                          当前场景物体的位置       世界坐标的 y轴
        Debug.DrawLine(Vector3.zero, transform.position, Color.blue);
        //              零点          当前场景物体的位置
        Debug.DrawLine(Vector3.zero, cross, Color.red);
        //              零点          叉积
	}
}
