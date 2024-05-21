using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Title,
    Prepare,
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
    [SerializeField] Text _uiTime;

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
                TitleAction();
                break;
            case GameState.Prepare:
                //StartCoroutine(PrepareCoroutine());
                break;
            case GameState.InGame:
                InGameAction();
                break;
            case GameState.Dead:
                DeadAction();
                break;
            case GameState.Result:
                EndAction();
                break;
            default:
                break;
        }
    }

    // Startになったときの変更時処理
    void TitleAction()
    {
        SetCurrentState(GameState.InGame);//とりあえず、開始後すぐゲーム実行
    }

    // Prepareになったときの変更時処理
    void PrepareCoroutine() //なにこれ。コールチンってなに？
    //IEnumerator PrepareCoroutine() //なにこれ。コールチンってなに？
    {
        //label.text = "3";
        //yield return new WaitForSeconds(1);
        //label.text = "2";
        //yield return new WaitForSeconds(1);
        //label.text = "1";
        //yield return new WaitForSeconds(1);
        //label.text = "";
        //SetCurrentState(GameState.InGame);
    }

    // InGameになったときの変更時処理
    void InGameAction()
    {
        //label.text = "ゲーム中";
    }

    // Deadになったときの変更時処理
    void DeadAction()
    {
    }

    // Resultになったときの変更時処理
    void EndAction()
    {
    }

    //Start
    public void Start()
    {
        
    }
    //Update
    public void Update()
    {
        switch (currentGameState)
        {
            case GameState.Title:
                
                break;
            case GameState.Prepare:
                
                break;
            case GameState.InGame:
                //タイムを加算
                gm_time += Time.deltaTime;
                //UI
                _uiTime.text = "タイム: " + gm_time.ToString();
                //_uiTime.text = "こんにちは";
                //UIManagerを呼び出して上げる

                break;
            case GameState.Dead:
                
                break;
            case GameState.Result:
                Debug.Log("ゲーム時間: " + gm_time);
                break;
            default:
                break;
        }
    }
}

