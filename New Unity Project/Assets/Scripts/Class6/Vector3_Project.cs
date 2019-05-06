using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_Project : MonoBehaviour {

    /*
     * Project (vector : Vector3, onNormal : Vector3)
     *  投影一个向量到另一个向量
     *      Project 投射，项目
     */
    public Transform target;
    public Vector3 rail;            //需要投影的坐标轴，（x = 0，y = 0，z = 0）只能设置其中一个值不为 0

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 heading = target.position - transform.position;             //两个场景物体的 坐标距离（向量heading）
        Vector3 project = Vector3.Project(heading, rail);                   //将 向量heading 投射到 rail

        Debug.DrawLine(transform.position, target.position, Color.green);   //两个场景物体 相连接的线段
        Debug.DrawLine(transform.position, project, Color.red);             //投影 得到的线段
	}
}
