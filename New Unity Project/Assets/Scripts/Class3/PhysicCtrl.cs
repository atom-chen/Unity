using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]           //添加这一行，可以强制使场景物体带有Rigidbody
public class PhysicCtrl : MonoBehaviour {

    //
    //   public Rigidbody rb;                        //Rigidbody 刚体对象
    //   public CollistionAndTrigger cat;            //访问 同一场景物体的其他脚本

    //   // Use this for initialization
    //   void Start () {
    //       rb = GetComponent<Rigidbody>();         //使用这个脚本的 场景物体 需要有Rigidbody

    //       rb.AddForce(0, 0, 10, ForceMode.Impulse);
    //       //Acceleration：加速度、Force：力、Impulse：冲量、VelocityChange：速度变化
    //       /*
    //        * 物理公式
    //        * F = M * A
    //        * I = F * T =M * V
    //        */

    //       cat = gameObject.GetComponent<CollistionAndTrigger>();
    //   }

    //// Update is called once per frame
    //void Update () {

    //}

    //   //Acceleration 模式下，在FixedUpdate 中调用
    //   /*
    //    * Update 是指游戏的逻辑
    //    * FixedUpdate 用于物理运算
    //    */
    //   private void FixedUpdate()
    //   {
    //       //rb.AddForce(0, 0, 1, ForceMode.Force);
    //   }
    //


    public Rigidbody rb;

    private void Awake()
    {
        rb.gameObject.GetComponent<Rigidbody>();
    }

    public void addTmpulse()
    {
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }
}
