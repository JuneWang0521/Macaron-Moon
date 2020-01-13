using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xMargin = 1f;      // 在摄像机跟上之前玩家可以在X移动的距离
    //public float yMargin = 1f;      // 在摄像机跟上之前玩家可以在Y移动的距离
    public float xSmooth = 8f;      // 摄像机在X轴上跟上目标的流畅度
    //public float ySmooth = 8f;      // 摄像机在Y轴上跟上目标的流畅度
    public Vector2 maxXAndY;        // 摄像机最大坐标
    public Vector2 minXAndY;		// 摄像机最小坐标

    private Transform player;       // 玩家元素

    void Awake()
    {
        // 设置玩家元素
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        player = GameObject.Find("player").transform;
    }

    bool CheckXMargin()
    {
        // 返回是否摄像机与玩家的距离大于X边距
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    //bool CheckYMargin()
    //{
    //    // 返回是否摄像机与玩家的距离大于Y边距
    //    return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    //}

    void FixedUpdate()
    {
        TrackPlayer();
    }

    void TrackPlayer()
    {
        // 初始化摄像机位置为当前目标的位置.
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        // If the player has moved beyond the x margin...
        if (CheckXMargin())
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);

        // If the player has moved beyond the y margin...
        //if (CheckYMargin())
        //    // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
        //    targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        //targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
