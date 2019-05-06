using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFramerate : MonoBehaviour {

    public int framerate;

    // Use this for initialization
    void Start () {
        framerate = Time.captureFramerate;          //framerate 初始化 为 Time.captureFramerate 的默认状态
    }
	
	// Update is called once per frame
	void Update () {
        /*
         * Time.captureFramerate 返回类型为 int
         *  用于录制游戏视频
         *      游戏时间的增长 与 游戏实际帧率更新时间同步
         *          当游戏遇到卡顿 或者 运行流畅 录屏录下来的实际帧率一样
         *              录制的视频按照帧率捕捉的图像。游戏播放的帧率速度只要恒定的，那么录制好的视频观看的速度也是恒定的
         */
        Time.captureFramerate = framerate;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.005f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }
	}

    private void OnGUI()
    {
        /*
         * Time 中只读的变量
         */
        GUILayout.TextArea("Game Time：" + Time.time.ToString(), 200);
                //Time.time                 从游戏开始到现在所用的时间

        GUILayout.TextArea("Game timeSinceLevelLoad：" + Time.timeSinceLevelLoad.ToString(), 200);
                //Time.timeSinceLevelLoad   这是以秒计算到最后的关卡已经加载完的时间

        GUILayout.TextArea("Delta Time：" + Time.deltaTime.ToString(), 200);
                //Time.deltaTime            以秒计算，完成最后一帧的时间

        GUILayout.TextArea("Fixed Time：" + Time.fixedTime.ToString(), 200);
                //Time.fixedTime            这是以秒计算自游戏开始的时间

        GUILayout.TextArea("SmoothDelta Time：" + Time.smoothDeltaTime.ToString(), 200);
                //Time.smoothDeltaTime      一个平滑淡出Time.deltaTime

        GUILayout.TextArea("Frame Count：" + Time.fixedTime.ToString(), 200);
                //Time.fixedTime            已经传递的帧的总算

        GUILayout.TextArea("Real Time：" + Time.realtimeSinceStartup.ToString(), 200);
                //Time.realtimeSinceStartup 以秒计，自游戏开始的实时时间

        GUILayout.TextArea("Unscaled Time：" + Time.unscaledTime.ToString(), 200);
                //Time.unscaledTime         以秒计算，完成最后一帧的时间（不计算Timescale）

        GUILayout.TextArea("UnscaledDelta Time：" + Time.unscaledDeltaTime.ToString(), 200);
                //Time.unscaledDeltaTime    从游戏开始到现在所用的时间（不计算Timescale）
    }
}
