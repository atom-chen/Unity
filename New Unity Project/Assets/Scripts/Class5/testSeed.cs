using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSeed : MonoBehaviour {
    /*
     * Random.value
     *  生成0 —— 1之间的随机数
     *  
     * Random.seed
     *  开发时，保证预先生成的一组随机数
     *      可以预先判断生成的随机数的结果
     *          一旦制定 随机种子 ，之后产生的所有随机数都与第一轮产生的相同
     */

    public int seed;
    private float[] noiseValues;

	// Use this for initialization
	void Start () {
        #pragma warning disable CS0618 // 类型或成员已过时
        Random.seed = seed;         //Random.Seed 设置用于随机数生成器的种子     每一轮生成的 5个随机数 都与第一轮的相同
        #pragma warning restore CS0618 // 类型或成员已过时

        noiseValues = new float[5];
        int i = 0;
        while (i < noiseValues.Length)
        {
            noiseValues[i] = Random.value;
            print(noiseValues[i]);
            i++;
        }
	}

    private void OnGUI()
    {
        int i = 0;
        while (i < noiseValues.Length)
        {
            GUILayout.TextArea(noiseValues[i].ToString(), 200);     //200   代表显示的数字的前后长度（显示的位数）（包括小数点）
            i++;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
