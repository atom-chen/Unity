using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp_LerpAngle : MonoBehaviour {

    /*
     * Lerp (from : float, to : float, t : float)
     *  在 x轴移动的 最大值 和最小值，移动到 maxX 后停止
     */
    public float minX = 0f;
    public float maxX = 10f;

    /*
     * LerpAngle (a : float, b : float, t : float)
     *  旋转角度有 0°(start) —— 60°(end)，旋转到 end 后停止
     */
    //public float start = 0f;
    //public float end = 60f;

    float startTime = 1f;   //需要花费的时间

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * Lerp
         *  基于浮点数 t 返回 a 到 b 之间的 移动 差值
         */
        transform.position = new Vector3(
            Mathf.Lerp(minX, maxX, Time.time - startTime),
            transform.position.y,
            transform.position.z);

        /*
         * LerpAngle
         *  基于浮点数 t 返回 a 到 b 之间的 角度 差值
         */
        //float current = Mathf.LerpAngle(start, end, Time.time - startTime);
        //transform.eulerAngles = new Vector3(
        //    transform.eulerAngles.x,
        //    current,
        //    transform.eulerAngles.z);
    }
}
