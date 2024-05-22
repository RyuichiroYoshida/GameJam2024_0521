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
    [SerializeField] int maxHealth = 3; //ヘルス
    public int Health;
    public PlayerLaneState LaneState; //レーン
    [SerializeField] float laneWide = 1.0f; //左右移動の振り幅
    [SerializeField] GameObject posBase = null; //位置の基準
    [SerializeField] string tagObstancle = "Obstancle";//障害物と判断するタグ

    //変数の定義
    GameObject _thisPlayer;

    //アサイン
    [SerializeField] GameObject _objLeft = null;
    [SerializeField] GameObject _objMiddle = null;
    [SerializeField] GameObject _objRight = null;
    GameManager _gameManager;

    void Start()
    {
        Health = maxHealth;
        _gameManager = GetComponent<GameManager>();
    }

    //
    public void GM_Update()
    {
        //KeyがDownした時のみ、レーンを移動
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

        //レーンに合わせて、インスタンシェントを作る
        Destroy(_thisPlayer);
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

        //死亡判定
        if (Health <= 0)
        {
            _gameManager.SetGameState(GameState.Dead);
        }
    }
    void LaneLeft()
    {
        UnityEngine.Vector2 pos = posBase.transform.position;
        pos[0] -= laneWide;
        _thisPlayer = Instantiate(_objLeft, pos, posBase.transform.rotation);
        //プレイヤーの設定
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneMiddle()
    {
        _thisPlayer = Instantiate(_objMiddle, posBase.transform.position, posBase.transform.rotation);
        //プレイヤーの設定
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneRight()
    {
        UnityEngine.Vector2 pos = posBase.transform.position;
        pos[0] += laneWide;
        _thisPlayer = Instantiate(_objRight, pos, posBase.transform.rotation);
        //プレイヤーの設定
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }

    //当たり判定
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.tag == tagObstancle)
        //{
            Debug.Log("当たっている");
            Health -= 1;
        //}

    }
}
