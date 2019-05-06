using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_OrthoNormalize : MonoBehaviour {

    /*
     * OrthoNormalize (ref normal : Vector3, ref tangent : Vector3, ref binormal : Vector3)
     *  使向量规范化 并且彼此相互垂直
     *  三个 Vector3 模长 形成一个 独立的坐标轴
     */
    public GameObject target1;
    public GameObject target2;

    Vector3 a, b, c, d, e, f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        a = transform.position;
        b = target1.transform.position;
        c = target2.transform.position;

        d = a;
        e = b;
        f = c;

        /*
         * 改变ref a ——> ref b与ref c形成的 独立坐标轴会改变
         * 改变 ref b或者ref c ，只会对 自身 形成的模长坐标轴 产生影响
         */
        Vector3.OrthoNormalize(ref a, ref b, ref c);

        /*
         * 场景物体的 原点 与 世界坐标的 原点 相连接
         */
        Debug.DrawLine(Vector3.zero, d, Color.yellow);
        Debug.DrawLine(Vector3.zero, e, Color.white);
        Debug.DrawLine(Vector3.zero, f, Color.black);

        /*
         * 三个 Vector3 模长 形成一个 独立的坐标轴
         */
        Debug.DrawLine(Vector3.zero, a, Color.red);
        Debug.DrawLine(Vector3.zero, b, Color.green);
        Debug.DrawLine(Vector3.zero, c, Color.blue);
	}
}
