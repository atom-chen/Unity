using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDown : MonoBehaviour
{

    public int countDown = 5;

    // Use this for initialization
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = "" + countDown;
        InvokeRepeating("TimeCount", 2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TimeCount()
    {
        if (countDown > 0)
        {
            countDown--;
            GetComponent<UnityEngine.UI.Text>().text = "" + countDown;
        }
        else
        {
            CancelInvoke();
        }
    }
}
