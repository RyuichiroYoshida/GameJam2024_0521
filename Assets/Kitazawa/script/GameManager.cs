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
    // �V���O���g��
    private static GameManager thisInstance;
    /// <summary>
    /// ���݂̃Q�[����ԁB
    /// �ύX����ꍇ�A�ȉ��̊֐����g�����ƁB<br/>
    /// <b>GameManager.SetGameState(GameState state)</b>
    /// </summary>
    public GameState currentGameState;

    //�A�T�C��
    [SerializeField] PlayerManager _playerManager = null;
    [SerializeField] UIManager _uiManager = null;
    //Manager�������Ƒ��₷

    // �ϐ��̒�`
    /// <summary>�^�C��</summary>
    public float gm_time;
    /// <summary>�X�R�A</summary>
    public int gm_score;
    Text label;

    void Awake()
    {
        //������
        thisInstance = this;
        gm_time = 0.0f;
        gm_score = 0;
        //���߂�GameState
        SetGameState(GameState.Title);
        DontDestroyOnLoad(this.GameObject());
    }

    /// <summary>
    /// ���݂̃Q�[�����(GameState)��ύX����B
    /// </summary>
    public void SetGameState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    // ��Ԃ��ς�������AChanged���������s
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

    //�Q�[����Ԃ���Update�����s
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
        //SetGameState(GameState.InGame);//�Ƃ肠�����A�J�n�シ���Q�[�����s
    }
    void TitleUpdate()
    {
     
    }

    // InGame
    void InGameChanged()
    {
        //label.text = "�Q�[����";
    }
    void InGameUpdate()
    {
        //�o�ߎ��Ԃ̊Ǘ�
        gm_time += Time.deltaTime;
        //�eUpdate�̌Ăяo��
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
        Debug.Log("�Q�[������: " + gm_time);
        _uiManager.EndText(gm_score);
    }
    void ResultUpdate()
    {

    }
}

