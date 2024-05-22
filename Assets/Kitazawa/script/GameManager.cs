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
    private static GameManager _thisInstance;
    /// <summary>
    /// ���݂̃Q�[����ԁB
    /// �ύX����ꍇ�A�ȉ��̊֐����g�����ƁB<br/>
    /// <b>GameManager.SetGameState(GameState state)</b>
    /// </summary>
    private GameState _currentGameState;

    //�A�T�C��
    [SerializeField] PlayerManager _playerManager = null;
    [SerializeField] UIManager _uiManager = null;
    [SerializeField] InGame _InGame = null;
    //Manager�������Ƒ��₷

    // �ϐ��̒�`
    /// <summary>�^�C��</summary>
    public float Gm_time;
    /// <summary>�X�R�A</summary>
    public int Gm_score;
    Text label;

    void Awake()
    {
        //������
        _thisInstance = this;
        Gm_time = 0.0f;
        Gm_score = 0;
        //���߂�GameState
        SetGameState(GameState.Title);
        DontDestroyOnLoad(this.GameObject());
    }

    /// <summary>
    /// ���݂̃Q�[�����(GameState)��ύX����B
    /// </summary>
    public void SetGameState(GameState state)
    {
        _currentGameState = state;
        OnGameStateChanged(_currentGameState);
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
        Gm_time += Time.deltaTime;
        //�eUpdate�̌Ăяo��
        _playerManager.GmUpdate();
        _uiManager.InGameText(Gm_time, Gm_score);
        _InGame.GmUpdate();
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
        Debug.Log("�Q�[������: " + Gm_time);
        _uiManager.EndText(Gm_score);
    }
    void ResultUpdate()
    {

    }
}

