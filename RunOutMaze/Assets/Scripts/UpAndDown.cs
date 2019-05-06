using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour {

    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 5)
        {
            this.transform.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            this.transform.GetComponent<Renderer>().enabled = false;
        }

        transform.Rotate(0, 45f * Time.deltaTime, 0, Space.World);   //以世界坐标的 Y 轴进行旋转

        float changingY = 1f;   //升降变化
        float maxY = 15f;        //上升的最大高度
        changingY = Mathf.PingPong(Time.time * 2, maxY);
        transform.position = new Vector3(
                transform.position.x,
                changingY,
                transform.position.z);
    }
}
