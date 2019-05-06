using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class t : MonoBehaviour
{

    /*
     * 获取 场景物体
     */
    GameObject player;
    GameObject target;
    GameObject[] timeBombs;
    GameObject[] bombs;
    GameObject next;
    GameObject globalObject;

    /*
     * 场景物体 材质
     */
    Color bakPlayerColor;
    Color bakTargetColor;
    Vector3 changingTimeBombColor;

    Vector3 targetScale;    //用于改变 target 的大小
    Vector3 targetDefaultScale; //target 默认大小

    int gameSum;            //关卡的总数量
    int gameNum;            //当前关卡号码，用于 打开下一游戏场景

    int playerChildCount;   //用于 计算 player 获取的子物体 childCount，使 player 不能获取多个子物体，只能有一个

    // Use this for initialization
    void Start()
    {
        targetDefaultScale = new Vector3(1, 1, 1);  //targetScale 默认大小

        targetScale = new Vector3(3, 3, 3);         //target 需要改变的大小

        gameSum = GlobalControl.Instance.gameSum;   //读取关卡总数


        //Time.timeScale = 1f;

        /*
         * 获取 场景物体
         */
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Target");
        timeBombs = GameObject.FindGameObjectsWithTag("TimeBomb");
        bombs = GameObject.FindGameObjectsWithTag("Bomb");
        next = GameObject.FindGameObjectWithTag("Next");
        globalObject = GameObject.FindGameObjectWithTag("GlobalObject");

        /*
         * 取消 重力
         */
        target.GetComponent<Rigidbody>().useGravity = false;

        /*
         * 取消 碰撞
         */
        target.GetComponent<Collider>().enabled = false;

        /*
         * 加上 触发器 Trigger
         */
        next.GetComponent<Collider>().isTrigger = true;

        /*
         * 备份 场景物体 材质
         */
        bakPlayerColor = player.GetComponent<Renderer>().material.color;
        bakTargetColor = target.GetComponent<Renderer>().material.color;
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
    void Update()
    {
        TakeTheTarget(target.transform.position);
        TheTimeBomb();
        collisionBomb();
    }

    /*
     * Target 子物体
     *  用于 通关
     */
    void TakeTheTarget(Vector3 targetPos)
    {
        target.transform.Rotate(0, 90f * Time.deltaTime, 0, Space.World);   //以世界坐标的 Y 轴进行旋转
        if (Vector3.Distance(player.transform.position, targetPos) < 10)
        {
            target.GetComponent<Renderer>().enabled = true;

            target.transform.localScale = targetScale;              //修改 target 大小

            if (Vector3.Distance(player.transform.position, targetPos) < 5)
            {
                target.transform.localScale = targetDefaultScale;   //恢复 target 大小
            }

            if (Input.GetKey(KeyCode.Q))
            {
                target.GetComponent<Renderer>().material.color = Color.green;

                target.transform.position = transform.TransformPoint(0, 0, 0);
                target.transform.parent = transform;
                target.GetComponent<Rigidbody>().isKinematic = true;
            }
            if (Input.GetKey(KeyCode.E))
            {
                if (target.transform.parent == this.transform)
                {
                    target.GetComponent<Renderer>().material.color = bakTargetColor;

                    transform.DetachChildren();
                }
            }

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
    void TheTimeBomb()
    {
        foreach (GameObject timeBomb in timeBombs)
        {
            float colorX = Mathf.PerlinNoise(Time.time, changingTimeBombColor.x);
            float colorY = Mathf.PerlinNoise(Time.time, changingTimeBombColor.y);
            float colorZ = Mathf.PerlinNoise(Time.time, changingTimeBombColor.z);
            timeBomb.GetComponent<Renderer>().material.color = new Color(colorX, colorY, colorZ);

            timeBomb.GetComponent<Collider>().enabled = false;

            timeBomb.transform.Rotate(0, 90f * Time.deltaTime, 0, Space.World); //以世界坐标的 Y 轴进行旋转
        }
    }

    /*
     * Bomb 子物体
     *  用于 显示本物体危险
     */
    void collisionBomb()
    {
        float changingY = 1f;   //升降变化
        float maxY = 10f;        //上升的最大高度
        changingY = Mathf.PingPong(Time.time * 2, maxY);
        foreach (GameObject bomb in bombs)
        {
            bomb.transform.position = new Vector3(
                bomb.transform.position.x,
                changingY,
                bomb.transform.position.z);

            bomb.GetComponent<Renderer>().material.color = Color.red;

            bomb.transform.Rotate(0, -180f * Time.deltaTime, 0, Space.World);   //以世界坐标的 Y 轴进行旋转
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
            if (gameNum == gameSum - 1)
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
        if (collision.gameObject.tag == "Destory")
        {
            Destroy(collision.gameObject);
        }
    }
}
