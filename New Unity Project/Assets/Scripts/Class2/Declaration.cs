using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Declaration : MonoBehaviour {

    public GameObject objectPublic;         //可见
    protected GameObject objectProtected;   //不可见
    private GameObject objectPrivate;       //不可见

    [SerializeField]
    GameObject objectSerialized;            //Inspector 中显示
    [HideInInspector]
    public GameObject objectNotPublic;      //Inspector 中隐藏

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
