using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour {

    GameObject globalObject;

    /*
     * player 移动脚本
     */

    public int force = 30;

    int gameNum;            //当前关卡号码

    // Use this for initialization
    void Start () {
        globalObject = GameObject.FindGameObjectWithTag("GlobalObject");

        gameNum = SceneManager.GetActiveScene().buildIndex;

        GetComponent<Rigidbody>().drag = 2f;        //添加 物理阻尼
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, 45f * Time.deltaTime, 0, Space.Self);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().AddForce(new Vector3(h, 0, v) * force);
    }

    /*
     * 触发效果
     *  "Bomb"  推力变为零 移动速度变为零
     *      游戏结束，重新加载当前游戏场景
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bomb")
        {
            //Time.timeScale = 0f;
            GameObject.FindGameObjectWithTag("Next").GetComponent<Collider>().isTrigger = false;
            //force = 0;
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene(gameNum);        //重新加载当前游戏场景
            Destroy(globalObject);
        }
    }
}
