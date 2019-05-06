using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    //public GameObject relateObj;

    /*public AnimationCurve animCurve;                //Curve 曲线
    float outputY;*/

    public GameObject target;                       //需要移动到的另一场景物体的位置

	// Use this for initialization
	void Start () {
        /*outputY = 0;*/

    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.Translate(0, 1.5f * Time.deltaTime, 0, Space.Self);      //Space.Self  以 自身坐标进行移动
        //this.transform.Translate(0, 1.5f * Time.deltaTime, 0, Space.World);     //Space.World 以 世界坐标进行移动

        /*
         * Translate
         */
        //this.transform.Translate(0, 1.5f * Time.deltaTime, 0, relateObj.transform); //以 其他物体的自身坐标方向进行移动

        /*
         * AnimationCurve
         */
        //outputY = animCurve.Evaluate(Time.deltaTime / 2f) * 2f;       //Evaluate 值
        //this.transform.position =
        //    new Vector3(transform.position.x + 1.5f * Time.deltaTime, outputY, transform.position.z);   //朝着 x轴 方向进行 outputY 的曲线运动

        MoveToTarget(target.transform.position);    //另一场景物体的位置
    }

    void MoveToTarget(Vector3 targetPos)            //另一场景物体的位置
    {
        //判断两个场景物体的距离
        if(Vector3.Distance(this.transform.position, targetPos)>1)       //Distance  距离
        {
            /*
             * 一
             */
            Vector3 direction = targetPos - transform.position;         //direction 方向
            /*一（1）*/
            //三维向量变成模长
            direction = direction.normalized;                           //normalized    归一化
            this.transform.Translate(direction * Time.deltaTime, Space.World);
            /*一（2）*/
            //速度比一（1）快
            //this.transform.Translate(direction * Time.deltaTime, Space.World);

            /*
             * 二
             */
            /*二（1）*/
            //速度快
            //this.transform.Translate(targetPos * Time.deltaTime, Space.World);
            /*二（2）*/
            //速度快
            //this.transform.Translate(targetPos * Time.deltaTime / 10, Space.World);
        }
    }
}
