using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey_GetButton : MonoBehaviour {

    /*
     * Input.GetKey  Input.GetButton
     *  返回类型 bool
     *      Input.GetKey    针对 键盘key 的操作，不需要经过 输入管理器控制（Input Manager）
     *      Input.GetButton 需要经过 输入管理器控制
     *  项目 建议 使用 Input.GetButton，避免使用Input.GetKey所带来的错误
     */
    //bool key;

    /*
     * GetButton    GetButtonDown   GetButtonUp
     *  返回类型 bool
     */
    bool keyGetButton;
    bool keyGetButtonDown;
    bool keyGetButtonUp;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * 3种
         *  建议使用 Input.GetButton
         */
        ////key = Input.GetKey(KeyCode.Space);
        ////key = Input.GetKey("Space");
        //key = Input.GetButton("Jump");

        //if (key)
        //{
        //    transform.localScale = new Vector3(2, 2, 2);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}

        keyGetButton = Input.GetButton("Jump");
        keyGetButtonDown = Input.GetButtonDown("Jump");
        keyGetButtonUp = Input.GetButtonUp("Jump");

        if (keyGetButton)
        {
            this.transform.Rotate(Vector3.up, 45f * Time.deltaTime);
        }
        if (keyGetButtonDown)
        {
            this.transform.localScale = new Vector3(2, 2, 2);
        }
        if (keyGetButtonUp)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
