using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Title,
    InGame,
    Dead,
    Result
}

public class GameManager : MonoBehaviour
{
    // これ
    public static GameManager thisInstance;

    // 現在のゲームステータス
    public GameState currentGameState;

    //アサイン
    [SerializeField] Text _uiTime; //後で消す
    [SerializeField] PlayerManager _playerManager;
    //Managerをもっと増やす

    // 変数の定義
    public float gm_time;
    Text label;

    void Awake()
    {
        //初期化
        thisInstance = this;
        gm_time = 0.0f;
        //初めのGameState
        SetCurrentState(GameState.Title);

        //GetComporment
        _playerManager = GetComponent<PlayerManager>();
    }

    public void Start()
    {

    }

    // 外からこのメソッドを使って状態を変更
    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    // 状態が変わったら変更時メソッドを実行
    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Title:
                TitleChanged();
                break;
            case GameState.InGame:
                InGameChanged();
                break;
            case GameState.Dead:
                DeadChanged();
                break;
            case GameState.Result:
                ResultChanged();
                break;
            default:
                break;
        }
    }

    // //シーンごとにUpdate
    public void Update()
    {
        switch (currentGameState)
        {
            case GameState.Title:
                TitleUpdate();
                break;
            case GameState.InGame:
                InGameUpdate();
                break;
            case GameState.Dead:
                DeadUpdate();
                break;
            case GameState.Result:
                ResultUpdate();
                break;
            default:

                break;
        }
    }

    // Titleになったときの変更時
    void TitleChanged()
    {
        //SetCurrentState(GameState.InGame);//とりあえず、開始後すぐゲーム実行
    }
    void TitleUpdate()
    {
        
    }

    // InGameになったときの変更時
    void InGameChanged()
    {
        //label.text = "ゲーム中";
    }
    void InGameUpdate()
    {
        _playerManager.GM_Update();
    }

    // Deadになったときの変更時処理
    void DeadChanged()
    {
    }
    void DeadUpdate()
    {

    }

    // Resultになったときの変更時処理
    void ResultChanged()
    {
        Debug.Log("ゲーム時間: " + gm_time);
    }
    void ResultUpdate()
    {

    }
}

