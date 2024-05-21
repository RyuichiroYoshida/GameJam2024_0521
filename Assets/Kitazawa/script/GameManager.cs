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

    // 例
    public float gm_time;
    Text label;

    void Awake()
    {
        thisInstance = this;
        SetCurrentState(GameState.Title);
        gm_time = 0.0f;
    }


    // 外からこのメソッドを使って状態を変更
    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    // 状態が変わったら何をするか -> メソッドを実行
    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Title:
                StartAction();
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

    // Startになったときの処理
    void StartAction()
    {
    }

    // Prepareになったときの処理
    //IEnumerator PrepareCoroutine() //なにこれ。コールチンってなに？
    //{
    //    //label.text = "3";
    //    //yield return new WaitForSeconds(1);
    //    //label.text = "2";
    //    //yield return new WaitForSeconds(1);
    //    //label.text = "1";
    //    //yield return new WaitForSeconds(1);
    //    //label.text = "";
    //    //SetCurrentState(GameState.InGame);
    //}
    // InGameになったときの処理
    void InGameAction()
    {
        label.text = "ゲーム中";

    }
    // Deadになったときの処理
    void DeadAction()
    {
    }
    // Resultになったときの処理
    void EndAction()
    {
    }

    private void Update()
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

