using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Coordinate : MonoBehaviour {

    public enum MoveDirection { idle, right, up, forward };
    public MoveDirection direct;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * 以 自身坐标 进行移动
         * Direction    方向、定向
         *  如果相乘的数字为负数（也可以是）
         *      则 x => -x       left
         *         y => -y      down
         *         z => -z      back
         */
        if (direct == MoveDirection.idle)                       //idle  虚度 、空转
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (direct == MoveDirection.right)                      //代表X 轴
        {
            GetComponent<Rigidbody>().velocity = transform.right * 1;
            //this.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f*Time.deltaTime, transform.position.z);
            //transform.position += Vector3.right * Time.deltaTime;
        }

        if (direct == MoveDirection.up)                         //代表Y 轴
        {
            GetComponent<Rigidbody>().velocity = transform.up * 1;
        }

        if (direct == MoveDirection.forward)                    //代表Z 轴
        {
            GetComponent<Rigidbody>().velocity = transform.forward * 1;
        }
    }
}
