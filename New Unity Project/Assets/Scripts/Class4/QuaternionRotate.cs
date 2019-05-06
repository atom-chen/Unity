using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionRotate : MonoBehaviour {

    //public Quaternion quat;                 //四元数  有4条轴，X,Y,Z,W     要有 旋转效果，需要先输入W 轴的数值

    /*
     * LookDirection
     */
    //public GameObject target;               //获取目标场景物体

    /*
     * FromToRotation
     */
    //public GameObject target1;              //获目标取场景物体1
    //public GameObject target2;              //获目标取场景物体2

    /*
     * RotateTowards
     */
    //public GameObject target;               //获取目标场景物体
    //public float speed;                     //设置当前场景物体的旋转速度

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.rotation = quat;     //要有 旋转效果，需要先输入W 轴的数值

        //Vector3 LookDirection = target.transform.position - transform.position;     //目标场景物体 与 当前场景物体 的方向向量，距离
        //transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.down);    //当前场景物体的 Z轴 对向 目标场景物体
        //当前场景物体的up（right）方向状态

        //transform.rotation = Quaternion.FromToRotation(target1.transform.up, target2.transform.up);
        //FromToRotation    用于计算 两个场景物体 的方向向量的 差值
        //  而后Quaternion.FromToRotation 折算成一个角度
        //      将返回值返回给 当前场景物体上
        //          两个场景物体 的方向向量的 差值 越大，当前场景物体的旋转角度越大

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, speed);
        //transform.rotation , target.transform.rotation
        //      当前场景物体 与 目标场景物体   的旋转角度一致
        //  速度可以进行一定量修改，可以达到当前场景物体有 缓慢旋转的效果
    }
}
