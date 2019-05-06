using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_Slerp : MonoBehaviour {

    /*
     * Slerp (from : Vector3, to : Vector3, t : float)
     *  当前场景物体 的位置会 瞬间变成 from : Vector3
     *  而后会快速移动至 to : Vector3
     *      当前场景物体 会视情况是否需要 直接 直线移动到 to : Vector3
     *      否则 会以 四元素 坐标 移动到 to : Vector3
     *          如果 t : float 时间减去一个数，当前场景物体会在 from : Vector3 等待这个数的时间再移动至 to : Vector3
     */
    public GameObject target1;
    public GameObject target2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Slerp(target1.transform.position, target2.transform.position, Time.time);
	}
}
