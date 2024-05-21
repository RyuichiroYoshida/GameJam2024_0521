using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerLaneState
{
    Left,
    Middle,
    Right
}
public class PlayerManager : MonoBehaviour
{
    //パラメーター
    public PlayerLaneState PlayLane;

    //変数の定義
    //bool keyDown_Hrzn = false;
    //float last_KeyDown_Hrzn;
    void GM_Start()
    {
        
    }

    //
    public void GM_Update()
    {
        //KeyがDownした時のみ、
        if (Input.GetKeyDown(KeyCode.D))//右
        {
            PlayLane += 1;//レーンを変更
        }
        if (Input.GetKeyDown(KeyCode.A))//左
        {
            PlayLane -= 1;//レーンを変更
        }

        //レーンに合わせて、変更
        //switch (PlayLane)
        //{
            //case PlayerLaneState.Left:
            //case PlayerLaneState.Middle:
            //case PlayerLaneState.Right:
            //case default:
        //}
    }

    //当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("当たっている");
    }
}
