using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awake_Start : MonoBehaviour {

    /*
     * 先运行Awake
     * 在运行Start
     * 
     * 如果取消勾选脚本
     *  只运行Awake
     *  
     *  如果取消勾选场景物体
     *  Start 和 Awake
     *  都不会运行
     */

    // Use this for initialization
    void Start () {
        Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Awake() {
        Debug.Log("Awake");
	}
}
