using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_Max_Min_Scale : MonoBehaviour {

    /*
     * Vector3.Max
     *  返回一个由两个向量的 最大 组件组成的向量
     *      Vector3(1, 2, 3)    Vector3(4, 3, 2)
     *          返回 Vector3(4, 3, 3)
     */

    /*
     * Vector3.Min
     *  返回一个由两个向量的 最小 组件组成的向量
     *      Vector3(1, 2, 3)    Vector3(4, 3, 2)
     *          返回 Vector3(1, 2, 2)
     */

    /*
     * Vector3.Scale
     *  由缩放的相同的组件对应 乘 以这个矢量的每个组件
     *      Vector3(1, 2, 3)    Vector3(4, 3, 2)
     *          Vector3(1, 2, 3) * Vector3(4, 3, 2) = Vector3(4, 6, 6)
     */

    public Vector3 v1 = new Vector3(1, 2, 3);
    public Vector3 v2 = new Vector3(4, 3, 2);

	// Use this for initialization
	void Start () {
        Debug.Log("Vector3.Max：" + Vector3.Max(v1, v2));    //返回 Vector3(4, 3, 3)

        Debug.Log("Vector3.Min：" + Vector3.Min(v1, v2));    //返回 Vector3(1, 2, 2)

        Debug.Log("Vector3.Scale：" + Vector3.Scale(v1, v2));    //Vector3(1, 2, 3) * Vector3(4, 3, 2) = Vector3(4, 6, 6)
        transform.localScale = Vector3.Scale(v1, v2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
