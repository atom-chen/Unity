using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Vector3 : MonoBehaviour {

    Vector3 v1;
    Vector3 v2;

    private void Awake()
    {
        v1 = transform.position;        //当前 场景物体 的位置(1, 1, 1)
    }

    // Use this for initialization
    void Start () {
        //v2 = v1.normalized;             //(1, 1, 1) —— sqr(1^2 + 1^2 + 1^2) == sqr(3) == 1.732051   v2 ——>1 / sqr(3) == 0.6 (0.6, 0.6, 0.6)
        //v2 = Vector3.Normalize(v1);     //与上面的一样
        v1.Normalize();

        Debug.Log("Magnitude：" + v1.magnitude.ToString());
        Debug.Log("the value of v1：" + v1.ToString());
        Debug.Log("the value of v2：" + v2.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        //GUILayout.TextArea("sqrMagnitude：" + transform.position.sqrMagnitude, 200);     //sqrMagnitude  平方级 2 -> 4
        //GUILayout.TextArea("Magnitude：" + transform.position.magnitude, 200);           //Magnitude         2 -> 2
    }
}
