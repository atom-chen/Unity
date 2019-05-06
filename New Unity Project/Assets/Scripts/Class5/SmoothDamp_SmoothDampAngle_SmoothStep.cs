using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDamp_SmoothDampAngle_SmoothStep : MonoBehaviour {

    /*
     * SmoothDamp
     *  场景物体 平滑 移动，移动到 target 后停止
     */
    //public float target;        //目标位置
    //float velocity = 0f;        //移动速度
    //public float maxSpeed;      //最高速度

    /*
     * SmoothDampAngle
     *  场景物体 平滑 旋转，旋转到 target 后停止
     */
    //public float target;
    //float velocity = 0f;
    //public float maxSpeed;

    /*
     * SmoothStep
     *  场景物体 平滑 渐进 移动，移动到 maxX 后停止
     */
    public float minX = 0f;
    public float maxX = 10f;
    float startTime = 1f;   //需要花费的时间

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * SmoothDamp
         *  随着时间的推移 逐渐 改变一个值到期望值
         */
        //transform.position = new Vector3(
        //    Mathf.SmoothDamp(transform.position.x, target, ref velocity, 1f, maxSpeed),
        //                //      当前位置        目标位置    移动速度    移动时间    最高速度
        //    transform.position.y,
        //    transform.position.z);

        /*
         * SmoothDampAngle
         *  随着时间的推移逐渐改变一个给定的角度到期望的角度
         */
        //transform.eulerAngles = new Vector3(
        //    transform.eulerAngles.x,
        //    Mathf.SmoothDampAngle(transform.eulerAngles.y, target, ref velocity, 1f, maxSpeed),
        //    transform.eulerAngles.z);

        /*
         * SmoothStep
         *  和 Lerp 类似，在 最小值 和 最大值 之间的插值，并在限制处 渐入渐出
         */
        transform.position = new Vector3(
            Mathf.LerpAngle(minX, maxX, Time.time - startTime),
            transform.position.y,
            transform.position.z);
    }
}
