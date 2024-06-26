using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    // シングルトン
    private static GameManager _thisInstance;
    /// <summary>
    /// 現在のゲーム状態。
    /// 変更する場合、以下の関数を使うこと。<br/>
    /// <b>GameManager.SetGameState(GameState state)</b>
    /// </summary>
    [SerializeField] private GameState _currentGameState;

    //アサイン
    [SerializeField] GameObject _InGameOb = null;
    [SerializeField] InGameManager _InGameSc = null;
    //[SerializeField] Dead _Dead = null;
    [SerializeField] GameObject _ResultOb = null;
    [SerializeField] ResultManager _ResultSc = null;
    //Managerをもっと増やす

    // 変数の定義
    Text label;

    void Awake()
    {
        //初期化
        _thisInstance = this;
        //初めのGameState
        SetGameState(GameState.Title);
        DontDestroyOnLoad(this.GameObject());
    }

    /// <summary>
    /// 現在のゲーム状態(GameState)を変更する。
    /// </summary>
    public void SetGameState(GameState state)
    {
        _currentGameState = state;
        OnGameStateChanged(_currentGameState);
    }

    // 状態が変わった時、Changed処理を実行
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

    //ゲーム状態ごにUpdateを実行
    public void Update()
    {
        switch (_currentGameState)
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

    // Title
    void TitleChanged()
    {
        //SetGameState(GameState.InGameManager);//とりあえず、開始後すぐゲーム実行
    }
    void TitleUpdate()
    {
     
    }

    // InGameManager
    void InGameChanged()
    {
        //label.text = "ゲーム中";
        _InGameOb = GameObject.Find("InGameManager");
        _InGameSc = _InGameOb.GetComponent<InGameManager>();
        _InGameSc.GmChanged();
    }
    void InGameUpdate()
    {
        //各Updateの呼び出し
        _InGameSc.GmUpdate();
    }

    // Dead
    void DeadChanged()
    {
        Debug.Log("Chandged");
    }
    void DeadUpdate()
    {
        SetGameState(GameState.Result);//すぐにリザルトに移行
        Debug.Log("Update");
    }

    // Result
    void ResultChanged()
    {
        _ResultOb = GameObject.Find("Result");
        _ResultSc = _ResultOb.GetComponent<ResultManager>();
    }
    void ResultUpdate()
    {
       _ResultSc.GmUpdate();
    }
}

