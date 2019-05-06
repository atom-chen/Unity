using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour {

    public float scale;

    public AnimationCurve curve;                    //curve 曲线
                                                    //ping pong 反向循环形式曲线

    // Use this for initialization
    void Start () {
        scale = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        scale = curve.Evaluate(Time.time) * 2f;     //Time.time 变化 以秒 为单位
        transform.localScale = new Vector3(scale, scale, scale);    //transform.localScale 相对于 父物体 的Scale=？ 倍大小
    }
}
