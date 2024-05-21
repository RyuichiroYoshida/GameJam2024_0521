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

    // ��
    public float gm_time;
    Text label;

    void Awake()
    {
        thisInstance = this;
        SetCurrentState(GameState.Title);
        gm_time = 0.0f;
    }


    // �O���炱�̃��\�b�h���g���ď�Ԃ�ύX
    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    // ��Ԃ��ς�����牽�����邩 -> ���\�b�h�����s
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

    // Start�ɂȂ����Ƃ��̏���
    void StartAction()
    {
    }

    // Prepare�ɂȂ����Ƃ��̏���
    //IEnumerator PrepareCoroutine() //�Ȃɂ���B�R�[���`�����ĂȂɁH
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
    // InGame�ɂȂ����Ƃ��̏���
    void InGameAction()
    {
        label.text = "�Q�[����";

    }
    // Dead�ɂȂ����Ƃ��̏���
    void DeadAction()
    {
    }
    // Result�ɂȂ����Ƃ��̏���
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
                //�^�C�������Z
                gm_time += Time.deltaTime;
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

