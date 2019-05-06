using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_operator : MonoBehaviour {

    /*
     * Vector3.operator
     *      两个向量 相加
     *  a : Vector3 + b : Vector3
     *  
     *      一个向量 减 另一个向量
     *  a : Vector3 - b : Vector3
     *  
     *      由一个 数 乘以 一个向量
     *  a : Vector3 * i : float
     *  
     *      由一个 数 除 一个向量
     *  a : Vector3 / i : float
     *  
     *      如果 向量 不同 返回真
     *  a : Vector3 != b : Vector3
     *  
     *      如果 两个向量 相等 返回真
     *  a : Vector3 == b : Vector3
     */

    public Vector3 v1 = new Vector3(1, 2, 3);
    public Vector3 v2 = new Vector3(4, 5, 6);
    public float i = 2;

    // Use this for initialization
    void Start () {
        Debug.Log("Vector3.operator");

        Debug.Log("a : Vector3 + b : Vector3：" + (v1 + v2));        // (1, 2, 3) + (4, 5, 6) = (5, 7, 9)
        Debug.Log("a : Vector3 - b : Vector3：" + (v1 - v2));        // (1, 2, 3) - (4, 5, 6) = (-3, -3, -3)
        Debug.Log("a : Vector3 * i : float：" + (v1 * i));           // (1, 2, 3) * 2 = (2, 4, 6)
        Debug.Log("a : Vector3 / i : float：" + (v1 / i));           // (1, 2, 3) / 2 = (0.5, 1, 1.5)
        Debug.Log("a : Vector3 != b : Vector3：" + (v1 != v2));      // (1, 2, 3) != (4, 5, 6) 返回 true
        Debug.Log("a : Vector3 == b : Vector3：" + (v1 == v2));      // (1, 2, 3) == (4, 5, 6) 返回 flase
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
