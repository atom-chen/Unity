using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    /*
     * 保存 全局变量
     *  一个游戏仅需定义一个用于保存数据的类
     */
    public int gameSum;         //需要保存的数据，保存 关卡 数，用于切换关卡
    public static GlobalControl Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(transform);       //不销毁当前场景物体
            Instance = this;
        }
        else if(Instance != null)
        {
            Destroy(transform);
        }
    }

    void SaveData()
    {
        GlobalControl.Instance.gameSum = gameSum;
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
