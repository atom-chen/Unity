using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject obj;

	// Use this for initialization
	void Start () {
        //obj = GameObject.Find("Sphere");      //会报错，先运行Variables 脚本的Start ，在Start中执行getObj(obj),而没有执行这里的语句
    }

    private void Awake()
    {
        obj = GameObject.Find("Sphere");
    }

    public void getObj(GameObject go)
    {
        if (obj == null)                        //如果场景中 没有Sphere 球体，将会执行为空语句
        {
            Debug.LogError("Null Reference");
            return;
        }
        go.transform.parent = obj.transform;    //如果场景中 有Sphere 球体，Sphere 球体将会成为选中物体的 父物体
    }

    // Update is called once per frame
    void Update () {
		
	}
}
