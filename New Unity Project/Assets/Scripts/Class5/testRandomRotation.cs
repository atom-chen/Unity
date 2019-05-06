using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRandomRotation : MonoBehaviour {

    private Quaternion[] rotationValues;        //旋转角度

    private Color[] colorValues;                //

	// Use this for initialization
	void Start () {
        rotationValues = new Quaternion[30];    //场景中有 30 个子物体（Cube），设置数组长度30
        colorValues = new Color[30];

        int i = 0;
        while (i < rotationValues.Length)
        {
            /*
             * Random 随机的
             * 
             *  只 读 函 数
             *  Random.value                //返回一个随机数，在0.0 —— 1.0之间
             *  Random.insideUnitCircle     //返回半径为1的 圆内 的一个 随机点
             *  Random.insideUnitSphere     //返回半径为1的 球体内 的一个 随机点
             *  Random.onUnitSphere         //返回半径为1的 球体在表面上 的一个 随机点
             *  Random.rotation             //返回一个随机 旋转角度
             *  Random.rotationUniform      //返回一个随机 旋转角度（平均分布）
             *  Random.Range(min,max)       //返回一个随机 float或者int 数，在 min和max 之间
             */
            rotationValues[i] = Random.rotationUniform;    //将随机产生的 旋转角度 赋予数组中
            colorValues[i] = new Color(Random.value, Random.value, Random.value);   //将随机产生的 三元色 赋予数组中

            Transform child = transform.GetChild(i);    //获取场景中的第 i 个子物体（Cube），并且实例化
            child.rotation = rotationValues[i];         //赋予随机产生的 旋转角度 到场景中的第 i 个子物体（Cube）
            child.GetComponent<Renderer>().material.color = colorValues[i];         //赋予随机产生的 三元色 到场景中的第 i 个子物体（Cube）

            i++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
