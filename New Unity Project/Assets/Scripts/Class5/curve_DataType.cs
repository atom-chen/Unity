using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curve_DataType : MonoBehaviour {

    public AnimationCurve curve_LerpAndMoveToward;
    /*
     * Lerp, MoveToward
     *  第二种线
     *      线性直线
     *      x = y
     */

    public AnimationCurve curve_SmoothStep;
    /*
     * SmoothStep
     *  第五种线
     *      先增后减
     *      类似于 sin 图像
     */

    public AnimationCurve curve_SmoothDamp;
    /*
     * SmoothDamp
     *  第四种线
     *     三元二次 方程 的图像，递增函数的
     *     x^2 + y = 0
     */

    public AnimationCurve curve;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }
}
