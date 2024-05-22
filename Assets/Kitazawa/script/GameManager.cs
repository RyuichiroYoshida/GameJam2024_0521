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
    private static GameManager thisInstance;
    /// <summary>
    /// 現在のゲーム状態。
    /// 変更する場合、以下の関数を使うこと。<br/>
    /// <b>GameManager.SetGameState(GameState state)</b>
    /// </summary>
    public GameState currentGameState;

    //アサイン
    [SerializeField] PlayerManager _playerManager = null;
    [SerializeField] UIManager _uiManager = null;
    //Managerをもっと増やす

    // 変数の定義
    /// <summary>タイム</summary>
    public float gm_time;
    /// <summary>スコア</summary>
    public int gm_score;
    Text label;

    void Awake()
    {
        //初期化
        thisInstance = this;
        gm_time = 0.0f;
        gm_score = 0;
        //初めのGameState
        SetGameState(GameState.Title);
        DontDestroyOnLoad(this.GameObject());
    }

    /// <summary>
    /// 現在のゲーム状態(GameState)を変更する。
    /// </summary>
    public void SetGameState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
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

    // Title
    void TitleChanged()
    {
        //SetGameState(GameState.InGame);//とりあえず、開始後すぐゲーム実行
    }
    void TitleUpdate()
    {
     
    }

    // InGame
    void InGameChanged()
    {
        //label.text = "ゲーム中";
    }
    void InGameUpdate()
    {
        //経過時間の管理
        gm_time += Time.deltaTime;
        //各Updateの呼び出し
        _playerManager.GM_Update();
        _uiManager.InGameText(gm_time, gm_score);
    }

    // Dead
    void DeadChanged()
    {
    }
    void DeadUpdate()
    {

    }

    // Result
    void ResultChanged()
    {
        Debug.Log("ゲーム時間: " + gm_time);
        _uiManager.EndText(gm_score);
    }
    void ResultUpdate()
    {

    }
}

