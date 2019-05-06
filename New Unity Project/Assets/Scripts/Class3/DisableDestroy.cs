using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDestroy : MonoBehaviour {

    private void OnEnable()             //脚本运行时启用
    {
        Debug.Log("script was Enabled ---------------");
    }

    private void OnDisable()            //脚本停止运行时启用
    {
        Debug.Log("script was OnDisable @@@@@@@@@@@@@@@");
    }

    private void OnDestroy()            //脚本停止运行，并销毁时启用
    {
        Debug.Log("script was OnDestroyed ###############");
    }
}
