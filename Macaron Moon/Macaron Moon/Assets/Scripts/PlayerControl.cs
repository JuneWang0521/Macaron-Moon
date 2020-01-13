using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveForce = 300f;          // 为玩家左右移动添加的力
    public float maxSpeed = 5f;             // 玩家在X轴上能够达到的最高速度

    private Transform groundCheck;            //地面检测元素
    private bool grounded = false;          //检查是否接触地面

    [HideInInspector]
    public bool allowToRun = true;

    public Animator animator;
    public GameObject m_gameObject;

    void Awake()
    {
        //初始化
        groundCheck = transform.Find("groundCheck");          
    }

    void Update()
    {
        //检测是否触及Ground层级中的物体
        grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(Input.GetKeyDown(KeyCode.Escape) && allowToRun == true)
        {
            allowToRun = false;
            m_gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        //储存水平方向的输入
        float h = Input.GetAxis("Horizontal");

        if(h != 0 && allowToRun)
        {
            animator.SetBool("move", true);
            if (h < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            animator.SetBool("move",false);
        }



        //如果玩家转向，或者还没达到最高速度
        if (h * GetComponent<Rigidbody>().velocity.x < maxSpeed  && allowToRun)
            // 为玩家添加水平方向上的力
            GetComponent<Rigidbody>().AddForce(Vector2.right * h * moveForce);

        // 如果玩家的水平速度超过最高速度
        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) > maxSpeed  && allowToRun)
            // 把玩家的水平速度置为方向上最高速度
            GetComponent<Rigidbody>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody>().velocity.x) * maxSpeed, GetComponent<Rigidbody>().velocity.y);
    }
}
