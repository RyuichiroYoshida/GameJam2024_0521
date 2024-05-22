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
    [SerializeField] private GameState _currentGameState;

    //�A�T�C��
    [SerializeField] GameObject _InGameOb = null;
    [SerializeField] InGameManager _InGameSc = null;
    //[SerializeField] Dead _Dead = null;
    //[SerializeField] Result _Result = null;
    //Manager�������Ƒ��₷

    // �ϐ��̒�`
    Text label;

    void Awake()
    {
        //������
        _thisInstance = this;
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
        //SetGameState(GameState.InGameManager);//�Ƃ肠�����A�J�n�シ���Q�[�����s
    }
    void TitleUpdate()
    {
     
    }

    // InGameManager
    void InGameChanged()
    {
        //label.text = "�Q�[����";
        _InGameOb = GameObject.Find("InGameManager");
        _InGameSc = _InGameOb.GetComponent<InGameManager>();
        _InGameSc.GmChanged();
    }
    void InGameUpdate()
    {
        //�eUpdate�̌Ăяo��
        _InGameSc.GmUpdate();
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
    }
    void ResultUpdate()
    {

    }
}

