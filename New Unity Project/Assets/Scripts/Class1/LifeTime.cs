using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{

    // Use this for initialization
    /*
     * 初始化函数，在所有Awake 函数运行完 之后，Update 函数运行之前
     * 一般用来给变量 赋值
     * 只有脚本激活时才能被调用
     */
    void Start()
    {
        Debug.Log("Start");
    }

    /*
     * 初始化函数，在游戏开始时系统自动调用
     * 一般用来 创建 变量
     * 无论脚本是否被激活都能被调用
     */
    private void Awake()
    {
        Debug.Log("Awake");
    }

    /*
     * 每隔固定时间调用一次
     * 一般用于物理运动
     */
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    /*
     * 每一帧调用一次
     * 一般用于非物理运动
     */
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }
}
