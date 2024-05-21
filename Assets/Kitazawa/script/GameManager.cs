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
    // ����
    public static GameManager thisInstance;

    // ���݂̃Q�[���X�e�[�^�X
    public GameState currentGameState;

    //�A�T�C��
    [SerializeField] Text _uiTime;

    // �ϐ��̒�`
    public float gm_time;
    Text label;

    void Awake()
    {
        //������
        thisInstance = this;
        gm_time = 0.0f;
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

    // Start�ɂȂ����Ƃ��̕ύX������
    void TitleAction()
    {
        SetCurrentState(GameState.InGame);//�Ƃ肠�����A�J�n�シ���Q�[�����s
    }

    // Prepare�ɂȂ����Ƃ��̕ύX������
    void PrepareCoroutine() //�Ȃɂ���B�R�[���`�����ĂȂɁH
    //IEnumerator PrepareCoroutine() //�Ȃɂ���B�R�[���`�����ĂȂɁH
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

    // InGame�ɂȂ����Ƃ��̕ύX������
    void InGameAction()
    {
        //label.text = "�Q�[����";
    }

    // Dead�ɂȂ����Ƃ��̕ύX������
    void DeadAction()
    {
    }

    // Result�ɂȂ����Ƃ��̕ύX������
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
                //�^�C�������Z
                gm_time += Time.deltaTime;
                //UI
                _uiTime.text = "�^�C��: " + gm_time.ToString();
                //_uiTime.text = "����ɂ���";
                //UIManager���Ăяo���ďグ��

                break;
            case GameState.Dead:
                
                break;
            case GameState.Result:
                Debug.Log("�Q�[������: " + gm_time);
                break;
            default:
                break;
        }
    }
}

