using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Take : MonoBehaviour {

    /*
     * 获取 场景物体
     */
    GameObject player;
    GameObject target;
    GameObject timeBomb;
    GameObject bomb;
    GameObject next;
    GameObject globalObject;
    GameObject destory;

    /*
     * 场景物体 材质
     */
    Color bakPlayerColor;
    Color bakTargetColor;
    Color bakTimeBombColor;
    Color bakBombColor;
    Vector3 changingTimeBombColor;

    int gameSum;            //关卡的总数量
    int gameNum;            //当前关卡号码，用于 打开下一游戏场景

    int playerChildCount;   //用于 计算 player 获取的子物体 childCount，使 player 不能获取多个子物体，只能有一个

    // Use this for initialization
    void Start () {
        gameSum = GlobalControl.Instance.gameSum;   //读取关卡总数


        //Time.timeScale = 1f;

        /*
         * 获取 场景物体
         */
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Target");
        timeBomb = GameObject.FindGameObjectWithTag("TimeBomb");
        bomb = GameObject.FindGameObjectWithTag("Bomb");
        next = GameObject.FindGameObjectWithTag("Next");
        globalObject = GameObject.FindGameObjectWithTag("GlobalObject");
        destory = GameObject.FindGameObjectWithTag("Destory");

        /*
         * 取消 重力
         */
        target.GetComponent<Rigidbody>().useGravity = false;
        timeBomb.GetComponent<Rigidbody>().useGravity = false;
        bomb.GetComponent<Rigidbody>().useGravity = false;

        /*
         * 取消 碰撞
         */
        target.GetComponent<Collider>().enabled = false;
        timeBomb.GetComponent<Collider>().enabled = false;

        /*
         * 加上 触发器 Trigger
         */
        bomb.GetComponent<Collider>().isTrigger = true;
        next.GetComponent<Collider>().isTrigger = true;

        /*
         * 备份 场景物体 材质
         */
        bakPlayerColor = player.GetComponent<Renderer>().material.color;
        bakTargetColor = target.GetComponent<Renderer>().material.color;
        bakTimeBombColor = timeBomb.GetComponent<Renderer>().material.color;
        bakBombColor = bomb.GetComponent<Renderer>().material.color;
        changingTimeBombColor = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f, 10f));

        /*
         * 用于 加载 下一游戏场景
         */
//#pragma warning disable CS0618 // 类型或成员已过时
//        gameNum = Application.loadedLevel;
//#pragma warning restore CS0618 // 类型或成员已过时
        gameNum = SceneManager.GetActiveScene().buildIndex;     //当前关卡的号码
    }

    // Update is called once per frame
    void Update () {
        TakeTheTarget(target.transform.position);
        TakeTheTimeBomb(timeBomb.transform.position);
        collisionBomb(bomb.transform.position);
    }

    /*
     * 可重复调用的方法
     *  按键 Q 获取子物体，并可以改变其材质
     *  按键 E 解除子物体，并恢复其原本材质
     */
    void inputKeyCode(GameObject go)
    {
        /*
         * 修改 target 和 timeBomb 的颜色
         */
        if (target.transform.parent == transform)
        {
            target.GetComponent<Renderer>().material.color = Color.green;
        }
        if(timeBomb.transform.parent == transform)
        {
            float colorX = Mathf.PerlinNoise(Time.time, changingTimeBombColor.x);
            float colorY = Mathf.PerlinNoise(Time.time, changingTimeBombColor.y);
            float colorZ = Mathf.PerlinNoise(Time.time, changingTimeBombColor.z);
            timeBomb.GetComponent<Renderer>().material.color = new Color(colorX, colorY, colorZ);
            player.GetComponent<Renderer>().material.color = new Color(colorX, colorY, colorZ);
        }
        else
        {
            player.GetComponent<Renderer>().material.color = bakPlayerColor;
        }

        /*
         * 获取、解除 子物体
         *  playerChildCount    使 player 不能获取多个子物体，只能有一个
         */
        playerChildCount = transform.childCount;
        if (Input.GetKey(KeyCode.Q) && playerChildCount == 0)
        {
            go.transform.position = transform.TransformPoint(0, 0, 0);
            go.transform.parent = transform;
            go.GetComponent<Rigidbody>().isKinematic = true;
            go.GetComponent<Collider>().enabled = false;
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (go.transform.parent == this.transform)
            {
                go.GetComponent<Renderer>().material.color = bakTimeBombColor;

                transform.DetachChildren();
            }
            player.GetComponent<Renderer>().material.color = bakPlayerColor;
        }
    }

    /*
     * Target 子物体
     *  用于 通关
     */
    void TakeTheTarget(Vector3 targetPos)
    {
        if(Vector3.Distance(player.transform.position, targetPos) < 3)
        {
            target.GetComponent<Renderer>().enabled = true;

            target.transform.Rotate(0, 90f * Time.deltaTime, 0, Space.World);   //以世界坐标的 Y 轴进行旋转

            #region inputKeyCode代替
            //if (Input.GetKey(KeyCode.Q))
            //{
            //    //target.GetComponent<Rigidbody>().useGravity = false;

            //    target.GetComponent<Renderer>().material.color = Color.green;

            //    target.transform.position = transform.TransformPoint(0, 0, 0);
            //    target.transform.parent = transform;
            //    target.GetComponent<Rigidbody>().isKinematic = true;
            //    target.GetComponent<Collider>().enabled = false;
            //}
            //if (Input.GetKey(KeyCode.E))
            //{
            //    if (target.transform.parent == this.transform)
            //    {
            //        target.GetComponent<Renderer>().material.color = bakTimeBombColor;

            //        transform.DetachChildren();
            //    }
            //}
            #endregion

            inputKeyCode(target);
        }
        else
        {
            target.GetComponent<Renderer>().enabled = false;
        }
    }

    /*
     * TimeBomb 子物体
     *  用于 模糊玩家
     */
    void TakeTheTimeBomb(Vector3 timeBombPos)
    {
        if (Vector3.Distance(player.transform.position, timeBombPos) < 3)
        {
            timeBomb.GetComponent<Renderer>().enabled = true;

            timeBomb.transform.Rotate(0, 90f * Time.deltaTime, 0, Space.World); //以世界坐标的 Y 轴进行旋转

            #region inputKeyCode代替
            //float colorX = Mathf.PerlinNoise(Time.time, changingTimeBombColor.x);
            //float colorY = Mathf.PerlinNoise(Time.time, changingTimeBombColor.y);
            //float colorZ = Mathf.PerlinNoise(Time.time, changingTimeBombColor.z);
            //timeBomb.GetComponent<Renderer>().material.color = new Color(colorX, colorY, colorZ);

            //if (Input.GetKey(KeyCode.Q))
            //{
            //    timeBomb.transform.position = transform.TransformPoint(0, 0, 0);
            //    timeBomb.transform.parent = transform;
            //    timeBomb.GetComponent<Rigidbody>().isKinematic = true;
            //    timeBomb.GetComponent<Collider>().enabled = false;
            //}
            //if (Input.GetKey(KeyCode.E))
            //{
            //    if (timeBomb.transform.parent == this.transform)
            //    {
            //        transform.DetachChildren();
            //    }
            //}
            #endregion

            inputKeyCode(timeBomb);
        }
        else
        {
            timeBomb.GetComponent<Renderer>().enabled = false;
            timeBomb.GetComponent<Renderer>().material.color = bakTargetColor;
        }
    }

    /*
     * Bomb 子物体
     *  用于 显示本物体危险
     */
    void collisionBomb(Vector3 bombPos)
    {
        float changingY = 1f;   //升降变化
        float maxY = 5f;        //上升的最大高度
        changingY = Mathf.PingPong(Time.time * 2, maxY);
        bomb.transform.position = new Vector3(
            bomb.transform.position.x,
            changingY,
            bomb.transform.position.z);

        if (Vector3.Distance(player.transform.position, bombPos) < 10)
        {
            bomb.GetComponent<Renderer>().enabled = true;

            bomb.transform.Rotate(0, -180f * Time.deltaTime, 0, Space.World);   //以世界坐标的 Y 轴进行旋转

            bomb.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            bomb.GetComponent<Renderer>().enabled = false;
        }
    }

    /*
     * 触发效果
     *  "Next" 物体下一关卡
     */
    private void OnTriggerEnter(Collider other)
    {
        if (target.transform.parent == player.transform && other.tag == "Next")
        {
            //Time.timeScale = 0f;
            if(gameNum == gameSum - 1)
            {
                SceneManager.LoadScene(0);
                Destroy(globalObject);      //销毁globalObject
            }
            else
            {
                SceneManager.LoadScene(gameNum + 1);
            }
        }
    }

    /*
     * player 碰撞 destory
     *  destory 将会销毁
     */
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Destory")
        {
            Destroy(collision.gameObject);
        }
    }
}
