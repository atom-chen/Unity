using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Functions : MonoBehaviour {

    string messageGetMouseButton;       //鼠标按下返回值

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //获取鼠标按下的反馈信息，返回类型bool  GetMouseButton(int)——int为 0 左击，int为 1 右击
        var input2 = Input.GetMouseButton(0);
        messageGetMouseButton = input2.ToString();

        Input.GetAxis("Horizontal");
    }

    private void OnGUI()
    {
        GUILayout.TextArea(messageGetMouseButton, 200);
    }
}
