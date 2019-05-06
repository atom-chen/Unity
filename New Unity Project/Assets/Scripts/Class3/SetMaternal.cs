using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaternal : MonoBehaviour {

    public Material mat;                        //材质对象（原本的材质）

    private Color init_color;                   //初始化颜色对象

	// Use this for initialization
	void Start () {
        init_color = mat.color;                 //将材质原本的颜色 备份
        mat.color = new Color(255, 255, 255);   //将原本的材质 进行修改
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        mat.color = init_color;                 //当脚本结束 并 销毁 时，将原本的材质进行恢复
    }
}
