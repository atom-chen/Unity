using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deltaTime : MonoBehaviour {

    /*
     * 项目开发时
     * 尽量使用 值类型
     */

    Vector3 pos;            //值类型       与场景物体 不共享内存，添加语句后场景物体不受影响
    Transform tran;         //引用类型      与场景物体 共享内存

	// Use this for initialization
	void Start () {
        pos = transform.position;
        tran = transform;
	}
	
	// Update is called once per frame
	void Update () {
        /*pos =
            new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);*/
        tran.position =
            new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);

        /*this.transform.position =
            new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);*/
    }
}
