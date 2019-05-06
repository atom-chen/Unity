using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableComponent : MonoBehaviour {

    public MeshRenderer mMean;                  //场景物体的渲染

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKeyDown(KeyCode.Space))    //当 按下 空格键 的时候，该 场景物体 将会取消渲染（不在场景中显示出来）
        {
            mMean.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.Space)) //当 放开 空格键 的时候，该 场景物体 将会渲染出来
        {
            mMean.enabled = true;
        }*/

        /*
         * 以上代码
         *  相当于
         * 以下代码
         *      但略有不同
         */
        /* 渲染开关 */
        if (Input.GetKeyDown(KeyCode.Space))    //同样是 只有按下空格键 的时候，但场景物体将会 持续 保持 本状态
        {
            mMean.enabled = !mMean.enabled;     //在语句后判断添加了一个“！”，代表反义取词赋值
        }
    }
}
