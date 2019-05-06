using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards_MoveTowardsAngle : MonoBehaviour {

    /*
     * MoveTowards (current : float, target : float, maxDelta : float)
     *  场景物体 匀速 前进，移动到 end 后停止
     */
    //public float end = 5f;
    //public float speed = 1f;

    /*
     * MoveTowardsAngle (current : float, target : float, maxDelta : float)
     *  场景物体 匀速 旋转，旋转到 target 后停止
     */
    public float target = 270f;
    public float speed = 45f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * MoveTowards
         *  改变一个 当前值（当前位置） 向 目标值 靠近
         */
        //transform.position = new Vector3(
        //    Mathf.MoveTowards(transform.position.x, end, Time.deltaTime * speed),
        //                //当前值（当前位置）     目标值     移动速度
        //    transform.position.y,
        //    transform.position.z);

        /*
         * MoveTowardsAngle
         *  改变一个 当前值（当前角度） 向 目标角度值 靠近
         */
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            Mathf.MoveTowardsAngle(transform.eulerAngles.y, target, Time.deltaTime * speed),
            transform.eulerAngles.z);
    }
}
