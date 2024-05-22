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
    [SerializeField] int _maxHealth = 3; //�w���X
    public int _health;
    public PlayerLaneState _laneState; //���[��
    [SerializeField] float _laneWide = 1.0f; //���E�ړ��̐U�蕝
    [SerializeField] GameObject _posBase = null; //�ʒu�̊
    [SerializeField] string _tagObstancle = "Obstancle";//��Q���Ɣ��f����^�O

    //�ϐ��̒�`
    GameObject _thisPlayer;

    //�A�T�C��
    [SerializeField] GameObject _objLeft = null;
    [SerializeField] GameObject _objMiddle = null;
    [SerializeField] GameObject _objRight = null;
    GameManager _gameManager;

    void Start()
    {
        _health = _maxHealth;
        _gameManager = GetComponent<GameManager>();
    }

    //
    public void GmUpdate()
    {
        //Key��Down�������̂݁A���[�����ړ�
        if (Input.GetKeyDown(KeyCode.D))//�E
        {
            _laneState += 1;//���[����ύX
        }
        if (Input.GetKeyDown(KeyCode.A))//��
        {
            _laneState -= 1;//���[����ύX
        }

        //���[�����ł���������A�͈͓��ɔ[�߂�
        int iLane = (int)_laneState;
        if (iLane >= 2)
        {
            _laneState = PlayerLaneState.Right;
        }
        else if (iLane <= -1) 
        {
            _laneState = PlayerLaneState.Left;
        }

        //���[���ɍ��킹�āA�C���X�^���V�F���g�����
        Destroy(_thisPlayer);
        switch (_laneState)
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
        if (_health <= 0)
        {
            _gameManager.SetGameState(GameState.Dead);
        }
    }
    void LaneLeft()
    {
        UnityEngine.Vector2 pos = _posBase.transform.position;
        pos[0] -= _laneWide;
        _thisPlayer = Instantiate(_objLeft, pos, _posBase.transform.rotation);
        //�v���C���[�̐ݒ�
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneMiddle()
    {
        _thisPlayer = Instantiate(_objMiddle, _posBase.transform.position, _posBase.transform.rotation);
        //�v���C���[�̐ݒ�
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneRight()
    {
        UnityEngine.Vector2 pos = _posBase.transform.position;
        pos[0] += _laneWide;
        _thisPlayer = Instantiate(_objRight, pos, _posBase.transform.rotation);
        //�v���C���[�̐ݒ�
        SpriteRenderer spr = _thisPlayer.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }

    //�����蔻��
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _tagObstancle)
        {
            Debug.Log("�������Ă���");
            _health -= 1;
        }

    }
}
