using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedUpdate_Update : MonoBehaviour {

    /*
     * Time.deltaTime
     *      这条语句所经历的时间差
     */

    void FixedUpdate () {                   //每隔固定时间调用一次
        Debug.Log("————————FixedUpdate time:"+Time.deltaTime);
	}

	void Update() {                         //每一帧调用一次
        Debug.Log("Update time:" + Time.deltaTime);
	}
}
