using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour {

    /*
     * PerlinNoise  噪声图
     *  取值范围是 0 —— 10
     */

    public Material m;          //场景物体 材质对象

    Vector3 colorSpace;         //三维数组对象，用于设置场景物体的颜色

    // Use this for initialization
    void Start () {
        m = GetComponent<Renderer>().material;      //初始化当前材质，有备份当前材质的功能

        /*
         * 
         */
        colorSpace = new Vector3(
            Random.Range(0f, 10f),
            Random.Range(0f, 10f),
            Random.Range(0f, 10f));
        //value 返回一个随机数，在0.0（包括）～1.0（包括）之间，材质变化 不明显
        //Range 返回一个随机浮点数，在min（包含）和max（包含）之间，材质变化 明显
        //PerlinNoise   取值范围是 0 —— 10
    }

    // Update is called once per frame
    void Update () {
        float colorX = Mathf.PerlinNoise(Time.time, colorSpace.x);
        float colorY = Mathf.PerlinNoise(Time.time, colorSpace.y);
        float colorZ = Mathf.PerlinNoise(Time.time, colorSpace.z);

        m.color = new Color(colorX, colorY, colorZ);
        //当前 场景物体 将会 缓慢且均匀 产生变化
    }
}
