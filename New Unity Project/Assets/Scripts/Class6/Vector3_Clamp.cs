using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_Clamp : MonoBehaviour {

    /*
     * ClampMagnitude (vector : Vector3, maxLength : float) 
     *  钳制向量
     *      用于限制 场景物体 的活动范围，以 半径radius 的长度内进行活动
     *          abc=Vector3(0,10,0);
     *          abc=Vector3.ClampMagnitude(abc, 2);
     *          abc返回的是Vector3(0,2,0)
     *          
     *          abc=Vector3(0,10,0);
     *          abc=Vector3.ClampMagnitude(abc, 12);
     *          abc返回的是Vector3(0,10,0)
     */

    Vector3 v;
    public float radius = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        v = transform.position;
        v = Vector3.ClampMagnitude(v, radius);
        transform.position = v;
	}

    private void OnGUI()
    {
        GUILayout.TextArea("ClampMagnitude：" + v);
    }
}
