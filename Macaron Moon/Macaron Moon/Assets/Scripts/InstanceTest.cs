using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceTest : MonoBehaviour
{
    public GameObject obj; //传入的预设
    private Transform tran;

    // Use this for initialization
    //void Start()
    //{
    //    //参数一：是预设 参数二：实例化预设的坐标  参数三：实例化预设的旋转角度
    //    GameObject instance = (GameObject)Instantiate(obj, transform.position, transform.rotation);
    //    //这里 transform.position，transform.rotation分别代表的是相机和坐标和 旋转角度
    //}

    void Start()
    {
        tran = GameObject.Find("DialogBox ").GetComponent<Transform>();
    }

    public void OnInstance()
    {
        GameObject instance = (GameObject)Instantiate(obj, tran.position+new Vector3(0,100,0), tran.rotation,tran);
    }
}
