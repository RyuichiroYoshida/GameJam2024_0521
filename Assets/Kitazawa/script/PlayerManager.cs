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
    [SerializeField] int _maxHealth = 3; //ヘルス
    public int _health;
    public PlayerLaneState _laneState; //レーン
    [SerializeField] float _laneWide = 1.0f; //左右移動の振り幅
    [SerializeField] GameObject _posBase = null; //位置の基準
    [SerializeField] string _tagObstancle = "Obstancle";//障害物と判断するタグ

    //変数の定義
    GameObject _thisPlayer;

    //アサイン
    [SerializeField] GameObject _objLeft = null;
    [SerializeField] GameObject _objMiddle = null;
    [SerializeField] GameObject _objRight = null;
    GameManager _gameManager;

    void Start()
    {
        _health = _maxHealth;
        _gameManager = GetComponent<GameManager>();
    }

    //
    public void GmUpdate()
    {
        //KeyがDownした時のみ、レーンを移動
        if (Input.GetKeyDown(KeyCode.D))//右
        {
            _laneState += 1;//レーンを変更
        }
        if (Input.GetKeyDown(KeyCode.A))//左
        {
            _laneState -= 1;//レーンを変更
        }

        //レーンがでかすぎたら、範囲内に納める
        int iLane = (int)_laneState;
        if (iLane >= 2)
        {
            _laneState = PlayerLaneState.Right;
        }
        else if (iLane <= -1) 
        {
            _laneState = PlayerLaneState.Left;
        }

        //レーンに合わせて、インスタンシェントを作る
        Destroy(_thisPlayer);
        switch (_laneState)
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
        if (_health <= 0)
        {
            _gameManager.SetGameState(GameState.Dead);
        }
    }
    void LaneLeft()
    {
        UnityEngine.Vector2 pos = _posBase.transform.position;
        pos[0] -= _laneWide;
        _thisPlayer = Instantiate(_objLeft, pos, _posBase.transform.rotation);
        //プレイヤーの設定
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneMiddle()
    {
        _thisPlayer = Instantiate(_objMiddle, _posBase.transform.position, _posBase.transform.rotation);
        //プレイヤーの設定
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneRight()
    {
        UnityEngine.Vector2 pos = _posBase.transform.position;
        pos[0] += _laneWide;
        _thisPlayer = Instantiate(_objRight, pos, _posBase.transform.rotation);
        //プレイヤーの設定
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }

    //当たり判定
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _tagObstancle)
        {
            Debug.Log("当たっている");
            _health -= 1;
        }

    }
}
