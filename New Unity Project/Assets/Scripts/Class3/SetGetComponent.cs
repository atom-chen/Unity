using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGetComponent : MonoBehaviour {

    public PhysicCtrl[] PSCs;

    private void Awake()
    {
        PSCs = new PhysicCtrl[3];
    }

    private void OnEnable()
    {
        /*
         * 分别获取添加其他脚本
         */
        PSCs[0] = gameObject.GetComponentInParent<PhysicCtrl>();            //Parent    是寻找Cube1
        PSCs[1] = gameObject.GetComponentInChildren<PhysicCtrl>();          //Children  是寻找Test
        PSCs[2] = GameObject.Find("Wall").GetComponent<PhysicCtrl>();       //  寻找Wall
    }

    // Use this for initialization
    void Start () {
		foreach(PhysicCtrl psc in PSCs)
        {
            psc.addTmpulse();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
