using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {

    /*
     * 值类型
     */
    ////public bool booleanValue;
    ////public float floatValue = 1.0f;
    ////public int intValue;
    ////public Vector2 vector2Value;            //经常用到      二维数组
    ////public Vector3 vector3Value;            //经常用到      三维数组
    ////public Quaternion quaternionValue;      //经常用到      四元数
    ////public byte byteValue;
    ////public string stringValue;
    ////public enum emType { A, B, C}
    ////public emType em;

    /*
     * 引用类型
     */
    public GameObject otherObject;
    test testScript;

    ////private void Reset()
    ////{
    ////    floatValue = 2.0f;
    ////}

    // Use this for i        testScript = otherObject.AddComponent<test>();nitialization
    void Start () {
        ////otherObject = GameObject.
        ///("Cube");                      //以场景 物体名字 进行查找
        ////otherObject = GameObject.FindGameObjectWithTag("Cubes");    //以场景 物体标签 进行查找

        testScript = otherObject.AddComponent<test>();
        testScript.getObj(otherObject);
    }
}
