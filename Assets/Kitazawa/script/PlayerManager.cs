using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using static UnityEngine.Mathf;

public enum PlayerLaneState
{
    Left,
    Middle,
    Right
}
public class PlayerManager : MonoBehaviour
{
    //�p�����[�^�[
    [SerializeField] int maxHealth = 3; //�w���X
    public int Health;
    public PlayerLaneState LaneState; //���[��
    [SerializeField] float laneWide = 1.0f; //���E�ړ��̐U�蕝
    [SerializeField] GameObject posBase = null; //�ʒu�̊
    [SerializeField] string tagObstancle = "Obstancle";//��Q���Ɣ��f����^�O

    //�ϐ��̒�`
    GameObject _thisPlayer;

    //�A�T�C��
    [SerializeField] GameObject _objLeft = null;
    [SerializeField] GameObject _objMiddle = null;
    [SerializeField] GameObject _objRight = null;
    GameManager _gameManager;

    void Start()
    {
        Health = maxHealth;
        _gameManager = GetComponent<GameManager>();
    }

    //
    public void GM_Update()
    {
        //Key��Down�������̂݁A���[�����ړ�
        if (Input.GetKeyDown(KeyCode.D))//�E
        {
            LaneState += 1;//���[����ύX
        }
        if (Input.GetKeyDown(KeyCode.A))//��
        {
            LaneState -= 1;//���[����ύX
        }

        //���[�����ł���������A�͈͓��ɔ[�߂�
        int iLane = (int)LaneState;
        if (iLane >= 2)
        {
            LaneState = PlayerLaneState.Right;
        }
        else if (iLane <= -1) 
        {
            LaneState = PlayerLaneState.Left;
        }

        //���[���ɍ��킹�āA�C���X�^���V�F���g�����
        Destroy(_thisPlayer);
        switch (LaneState)
        {
            case PlayerLaneState.Left:
                LaneLeft();
                break;
            case PlayerLaneState.Middle:
                LaneMiddle();
                break;
            case PlayerLaneState.Right:
                LaneRight();
                break;
            default:
                break;
        }

        //���S����
        if (Health <= 0)
        {
            _gameManager.SetGameState(GameState.Dead);
        }
    }
    void LaneLeft()
    {
        UnityEngine.Vector2 pos = posBase.transform.position;
        pos[0] -= laneWide;
        _thisPlayer = Instantiate(_objLeft, pos, posBase.transform.rotation);
        //�v���C���[�̐ݒ�
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneMiddle()
    {
        _thisPlayer = Instantiate(_objMiddle, posBase.transform.position, posBase.transform.rotation);
        //�v���C���[�̐ݒ�
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneRight()
    {
        UnityEngine.Vector2 pos = posBase.transform.position;
        pos[0] += laneWide;
        _thisPlayer = Instantiate(_objRight, pos, posBase.transform.rotation);
        //�v���C���[�̐ݒ�
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }

    //�����蔻��
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.tag == tagObstancle)
        //{
            Debug.Log("�������Ă���");
            Health -= 1;
        //}

    }
}
