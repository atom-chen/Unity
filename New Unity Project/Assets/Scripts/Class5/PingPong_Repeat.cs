using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong_Repeat : MonoBehaviour {

    public float scale = 1f;            //初始化变量，用于修改当前场景物体 y轴 的伸展

    float startTime = 5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * Repeat
         *  循环数值t，0到length之间。t值永远不会大于length的值，也永远不会小于0
         *      每一次运算当 t 快要接近 length 时，t 就会重新归 0
         */
        //scale = Mathf.Repeat(Time.time, 2);         //Repeat    重复
        //transform.localScale = new Vector3(transform.localScale.x, scale, transform.localScale.z);
        //  localScale  本地缩放（以当前场景物体坐标为基准）  transform.localScale.x    当前场景物体的缩放 x轴（表示不变）
        //  lossyScale  世界缩放


        /*
         * PingPong
         *  让数值t在，0到length之间往返。t值永远不会大于length的值，也永远不会小于0
         *      每一次运算当 t 快要接近 length 时，t 就会逐渐缩小直到变为 0
         */
        //scale = Mathf.PingPong(Time.time, 2);
        //transform.localScale = new Vector3(transform.localScale.x, scale, transform.localScale.z);
    }
}
