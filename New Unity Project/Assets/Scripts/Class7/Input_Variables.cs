using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Variables : MonoBehaviour {

    string messageAnyKey;               //是否 有某一按键或鼠标按钮此时被按住

    string messageAnyKeyDown;           //在第一帧用户按下某一按键或鼠标按钮

    string messageMousePosition;        //当前所在像素坐标的鼠标位置（只读）屏幕或窗口的左下角是坐标系的（0,0）坐标。右上角的坐标是（屏幕宽度值，屏幕高度值）

    string messageMousePresent;         //指示是否检测到鼠标设备

    string messageMouseScrollDelta;     //当前鼠标滚动增量

    string messageMultiTouchEnabled;    //此属性表明此系统是否支持多点触控

    string messageStylusTouchSupported; //当设备或平台支持触笔触摸时返回true

    string messageTouchCount;           //触摸的数量。每一帧之内都一定不会改变

    string messageTouchPressureSupported;//让用户检查是否支持触摸压力

    string messageTouchSupported;       //返回当前运行应用程序的设备 是否 支持 触摸输入

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey == Input.GetKey(KeyCode.W))
        {
            //返回类型bool
            messageAnyKey = Input.anyKey.ToString();
        }

        if (Input.anyKeyDown == Input.GetKey(KeyCode.W))
        {
            //返回bool
            messageAnyKeyDown = Input.anyKeyDown.ToString();
        }

        //获取鼠标位置信息，返回类型Vector3
        messageMousePosition = Input.mousePosition.ToString();

        //返回bool
        messageMousePresent = Input.mousePresent.ToString();

        //返回 二维数组，鼠标滚动的深度Y 依据系统的默认设置
        messageMouseScrollDelta = Input.mouseScrollDelta.ToString();

        //返回bool
        messageMultiTouchEnabled = Input.multiTouchEnabled.ToString();

        //返回bool
        messageStylusTouchSupported = Input.stylusTouchSupported.ToString();

        //返回int
        messageTouchCount = Input.touchCount.ToString();

        //返回bool
        messageTouchPressureSupported = Input.touchPressureSupported.ToString();

        //返回bool
        messageTouchSupported = Input.touchSupported.ToString();
    }

    private void OnGUI()
    {
        GUILayout.TextArea("anyKey.W：" + messageAnyKey, 200);
        GUILayout.TextArea("anyKeyDown.W：" + messageAnyKeyDown, 200);
        GUILayout.TextArea("mousePosition：" + messageMousePosition, 200);
        GUILayout.TextArea("mousePresent：" + messageMousePresent, 200);
        GUILayout.TextArea("mouseScrollDelta：" + messageMouseScrollDelta, 200);
        GUILayout.TextArea("multiTouchEnabled：" + messageMultiTouchEnabled, 200);
        GUILayout.TextArea("stylusTouchSupported：" + messageStylusTouchSupported, 200);
        GUILayout.TextArea("touchCount：" + messageTouchCount, 200);
        GUILayout.TextArea("touchPressureSupported：" + messageTouchPressureSupported, 200);
        GUILayout.TextArea("touchSupported：" + messageTouchSupported, 200);
    }
}
