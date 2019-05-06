using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndDirection : MonoBehaviour {

    public GameObject cube;

    private void Awake()
    {
        cube = GameObject.Find("Cube1");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q))                    //当按下键盘Q 后执行以下语句
        {
            /*
             * transform.TransformPoint
             *      TransformPoint  将 自身的 坐标 转换成 世界坐标
             */
            cube.transform.position = transform.TransformPoint(0, 0, 2);    //将捕获的场景物体放到镜头面前

            cube.transform.parent = transform;          //将场景物体的 父物体 设置为镜头的 子物体
                                                        //如果不加这一句 目标场景物体 不会跟随镜头移动
            cube.GetComponent<Rigidbody>().isKinematic = true;  //Kinematic 运动学的    设置捕获的物体 不受物理碰撞（运动），不受其他作用的影响
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (cube.transform.parent == this.transform)    //判断是否捕获物体
            {
                Debug.Log("Local Position" + cube.transform.localPosition.ToString());      //输出相对于 镜头的坐标
                Debug.Log("World Position" + cube.transform.position.ToString());           //输出相对于 世界的坐标

                cube.GetComponent<Rigidbody>().isKinematic = false; //将当前场景物体设置为 受其他作用的影响
                transform.DetachChildren();             //Detach 分离     将当前场景物体解除 父子物体 的关系

                /*
                 * transform.TransformDirection
                 *      TransformDirection  将 自身的 方向向量 转换成 世界向量
                 */
                Vector3 camDirect = transform.TransformDirection(0, 0, 10);
                cube.GetComponent<Rigidbody>().AddForce(camDirect, ForceMode.Impulse);
            }
        }

        /*
         * fixedDeltaTime   以秒计间隔，在物理和其他固定帧率更新
         * timeScale        传递时间的缩放，这可以用于减慢运动效果
         * captureFramerate 时间会在每一帧（1.0 / captureFramerate）前进，不考虑真实时间
         * 
         * fixedDeltaTime 与 timeScale   需要一同 增大 或 缩小 相同的倍数，游戏画面才不会因帧率不连续造成而卡顿
         */
         //适用于类似 CF狙击 的慢镜头
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.005f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }
    }
}
