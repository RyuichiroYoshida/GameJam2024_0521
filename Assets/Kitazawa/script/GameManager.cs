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
    // ����
    public static GameManager thisInstance;
    // ���݂̃Q�[���X�e�[�^�X
    public GameState currentGameState;

    //�A�T�C��
    [SerializeField] Text _uiTime; //��ŏ���
    [SerializeField] ScriptableObject _playerManager;
    [SerializeField] ScriptableObject _uiManager;
    //Manager�������Ƒ��₷

    // �ϐ��̒�`
    public float gm_time;
    public int gm_score;
    Text label;

    void Awake()
    {
        //������
        thisInstance = this;
        gm_time = 0.0f;
        gm_score = 0;
        //���߂�GameState
        SetCurrentState(GameState.Title);
    }


    // �O���炱�̃��\�b�h���g���ď�Ԃ�ύX
    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    // ��Ԃ��ς������ύX�����\�b�h�����s
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

    // //�V�[�����Ƃ�Update
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

    // Title�ɂȂ����Ƃ��̕ύX��
    void TitleChanged()
    {
        //SetCurrentState(GameState.InGame);//�Ƃ肠�����A�J�n�シ���Q�[�����s
    }
    void TitleUpdate()
    {
        
    }

    // InGame�ɂȂ����Ƃ��̕ύX��
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

    // Dead�ɂȂ����Ƃ��̕ύX������
    void DeadChanged()
    {
    }
    void DeadUpdate()
    {

    }

    // Result�ɂȂ����Ƃ��̕ύX������
    void ResultChanged()
    {
        Debug.Log("�Q�[������: " + gm_time);
        _uiManager.EndText(gm_score);
    }
    void ResultUpdate()
    {

    }
}

