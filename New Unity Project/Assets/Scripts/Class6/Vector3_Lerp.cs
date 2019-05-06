using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_Lerp : MonoBehaviour {

    /*
     * Lerp (from : Vector3, to : Vector3, t : float)
     *  两个向量之间的线性插值
     */
    public Vector3 v1;
    public Vector3 v2;
    float startTime = 1f;   //需要花费的时间

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(v1, v2, Time.time);   //场景物体 位置 先变为v1，再缓慢移动到v2
	}
}
