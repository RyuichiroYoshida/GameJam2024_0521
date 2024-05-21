using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using static UnityEngine.Mathf;

public enum PlayerLaneState
{
    Left,
    Middle,
    Right
}
public class PlayerManager : MonoBehaviour
{
    //パラメーター
    public PlayerLaneState LaneState; //レーン
    [SerializeField] float LaneWide = 1.0f; //左右移動の振り幅
    [SerializeField] GameObject PosBase; //位置の基準

    //変数の定義
    GameObject _player;

    //アサイン
    [SerializeField] GameObject ObjLeft;
    [SerializeField] GameObject ObjMiddle;
    [SerializeField] GameObject ObjRight;
    void GM_Start()
    {
        
    }

    //
    public void GM_Update()
    {
        //KeyがDownした時のみ、
        if (Input.GetKeyDown(KeyCode.D))//右
        {
            LaneState += 1;//レーンを変更

        }
        if (Input.GetKeyDown(KeyCode.A))//左
        {
            LaneState -= 1;//レーンを変更
        }

        //レーンがでかすぎたら、範囲内に納める
        int iLane = (int)LaneState;
        if (iLane >= 2)
        {
            LaneState = PlayerLaneState.Right;
        }
        else if (iLane <= -1) 
        {
            LaneState = PlayerLaneState.Left;
        }

        //レーンに合わせて、変更
        Destroy(_player);
        switch (LaneState)
        {
            case PlayerLaneState.Left:
                LaneLeft();
                break;
            case PlayerLaneState.Middle:
                LaneMiddle();
                break;
            case PlayerLaneState.Right:
                LaneRight();
                break;
            default:
                break;
        }
    }
    void LaneLeft()
    {
        UnityEngine.Vector2 pos = PosBase.transform.position;
        pos[0] -= LaneWide;
        _player = Instantiate(ObjLeft, pos, PosBase.transform.rotation);
        //プレイヤーの設定
        SpriteRenderer spr = _player.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneMiddle()
    {
        _player = Instantiate(ObjMiddle, PosBase.transform.position, PosBase.transform.rotation);
        //プレイヤーの設定
        SpriteRenderer spr = _player.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneRight()
    {
        UnityEngine.Vector2 pos = PosBase.transform.position;
        pos[0] += LaneWide;
        _player = Instantiate(ObjRight, pos, PosBase.transform.rotation);
        //プレイヤーの設定
        SpriteRenderer spr = _player.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }

    //当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("当たっている");
    }
}
