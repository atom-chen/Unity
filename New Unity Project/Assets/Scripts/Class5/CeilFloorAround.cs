using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilFloorAround : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //testCeil();
        //testFloor();
        testRound();
    }

    /*
     * 测试   Mathf.Ceil、Mathf.Floor、Mathf.Round
     *      Mathf.Ceil  向上取整
     *      Mathf.Floor 向下取整
     *      Mathf.Round 四舍五入    如果数字末尾是 .5 ，因此它是在两个整数中间，不管是偶数或是奇数，将返回偶数
     *                                  如果 .5 前面是 偶数，则返回 .5 前面的偶数
     *                                  如果 .5 钱面是 奇数，则返回 更加远离 0 的偶数
     */
    void testCeil()
    {
        Debug.Log("testCeil：" + Mathf.Ceil(10.0f));     //10
        Debug.Log("testCeil：" + Mathf.Ceil(10.2f));     //11
        Debug.Log("testCeil：" + Mathf.Ceil(10.7f));     //11
        Debug.Log("testCeil：" + Mathf.Ceil(-10.0f));    //-10
        Debug.Log("testCeil：" + Mathf.Ceil(-10.2f));    //-10
        Debug.Log("testCeil：" + Mathf.Ceil(-10.7f));    //-10
    }
    void testFloor()
    {
        Debug.Log("testFloor：" + Mathf.Floor(10.0f));   //10
        Debug.Log("testFloor：" + Mathf.Floor(10.2f));   //10
        Debug.Log("testFloor：" + Mathf.Floor(10.7f));   //10
        Debug.Log("testFloor：" + Mathf.Floor(-10.0f));  //-10
        Debug.Log("testFloor：" + Mathf.Floor(-10.2f));  //-11
        Debug.Log("testFloor：" + Mathf.Floor(-10.7f));  //-11
    }
    void testRound()
    {
        Debug.Log("testRound：" + Mathf.Round(10.0f));   //10
        Debug.Log("testRound：" + Mathf.Round(10.2f));   //10
        Debug.Log("testRound：" + Mathf.Round(10.7f));   //11

        Debug.Log("testRound：" + Mathf.Round(10.5f));   //10
        Debug.Log("testRound：" + Mathf.Round(11.5f));   //12

        Debug.Log("testRound：" + Mathf.Round(-10.0f));  //-10
        Debug.Log("testRound：" + Mathf.Round(-10.2f));  //-10
        Debug.Log("testRound：" + Mathf.Round(-10.7f));  //-11

        Debug.Log("testRound：" + Mathf.Round(-10.5f));  //-10
        Debug.Log("testRound：" + Mathf.Round(-11.5f));  //-12
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
