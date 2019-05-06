using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Drag : MonoBehaviour {

    /*
     * 实现 鼠标拖拽 效果
     */

    public Camera mCamera = null;

    public float depth = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseEnter()
    {
        this.transform.localScale = new Vector3(2f, 2f, 2f);
    }

    private void OnMouseExit()
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnMouseOver()
    {
        this.transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.Self);
    }

    private void OnMouseDrag()
    {
        //第一种方法
        MoveObject();

        //第二种方法
        //MoveObect_fixedDepth();
    }

    /*
     * 第一种方法
     */
    void MoveObject()
    {
        Ray r = mCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        /*
         * Physics.Raycast(r, out hit, 1000f, 1)
         *  最后的 1 是 Inspector 控制面板 中 Tag 旁边的 Layer 选项
         *      1 代表 检测第一层，而本物体需要选为其他选项
         *      不填 默认 检测全部
         */
        if (Physics.Raycast(r, out hit, 1000f, 1))
        {
            this.transform.position = new Vector3(
                                            hit.point.x,
                                            hit.point.y + 1f,
                                            hit.point.z);
            Debug.DrawLine(r.origin, hit.point, Color.red);
        }
    }

    /*
     * 第二种方法
     */
    void MoveObect_fixedDepth()     //以一个固定的深度进行移动
    {
        Vector3 mouseScreen = Input.mousePosition;
        mouseScreen.z = depth;
        Vector3 mouseWorld = mCamera.ScreenToWorldPoint(mouseScreen);   //ScreenToWorldPoint    屏幕转世界位置
        this.transform.position = mouseWorld;
    }
}
