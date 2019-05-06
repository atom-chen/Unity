using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public GameObject target;
    Vector3 currentPosition;                    //用于获取当前场景物体的位置

    // Use this for initialization
    void Start () {
        /*
         * Euler
         *  欧拉角
         *  注意取值范围 0° --- 360°
         */
        //Debug.Log("World Euler Angle" + transform.eulerAngles.x);
        //Debug.Log("World Euler Angle" + transform.eulerAngles.y);
        //Debug.Log("World Euler Angle" + transform.eulerAngles.z);

        //Debug.Log("Local Euler Angle" + transform.localEulerAngles.x);
        //Debug.Log("Local Euler Angle" + transform.localEulerAngles.y);
        //Debug.Log("Local Euler Angle" + transform.localEulerAngles.z);

        currentPosition = transform.position;   //获取当前场景物体的位置
    }
	
	// Update is called once per frame
	void Update () {
        /*
         * transform.Rotate
         *  旋转功能
         *  可以围绕 自身坐标 或者 世界坐标 进行旋转
         *          Space.Self      Space.World
         */
        //this.transform.Rotate(0, 45f * Time.deltaTime, 0, Space.World);     //绕 y轴 进行旋转

        //this.transform.Rotate(new Vector3(1, 1, 1), 45f * Time.deltaTime, Space.World);
        //Vector3 top = new Vector3(this.transform.position.x + 5f,
        //                        this.transform.position.y + 5f,
        //                        this.transform.position.z + 5f);
        //Vector3 botton = new Vector3(this.transform.position.x - 5f,
        //                        this.transform.position.y - 5f,
        //                        this.transform.position.z - 5f);
        //Debug.DrawLine(top, botton, Color.red);                    //画出参考的坐标轴

        //this.transform.Rotate(Vector3.up * 45f * Time.deltaTime, Space.World);  //up 绕 y轴 进行旋转


        /*
         * transform.RotateAround
         *  围绕其他物体进行旋转
         *  类似 行星围绕 恒星
         */
        //this.transform.RotateAround(target.transform.position, Vector3.up, 45f * Time.deltaTime);


        /*
         * transform.LookAt
         * 常用于摄像机
         * 让摄像机围绕场景物体进行旋转
         */
        //this.transform.LookAt(target.transform.position);


        //RotateToTarget(target.transform.position);
    }

    void RotateToTarget(Vector3 targetPos)
    {
        Vector3 direction = (targetPos - currentPosition).normalized;       //目标场景物体与当前场景物体的距离（模长）
        Quaternion currentRotation = this.transform.rotation;               //获取 当前场景物体的当前旋转角度

        Quaternion targetRotation = Quaternion.LookRotation(direction);     //目标场景物体 定取方向

        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, 45f * Time.deltaTime);
                                                                            //向当前方向进行旋转
    }
}
