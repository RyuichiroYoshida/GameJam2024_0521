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
    public PlayerLaneState LaneState; //���[��
    [SerializeField] float LaneWide = 1.0f; //���E�ړ��̐U�蕝
    [SerializeField] GameObject PosBase; //�ʒu�̊

    //�ϐ��̒�`
    GameObject _player;

    //�A�T�C��
    [SerializeField] GameObject ObjLeft;
    [SerializeField] GameObject ObjMiddle;
    [SerializeField] GameObject ObjRight;
    void GM_Start()
    {
        
    }

    //
    public void GM_Update()
    {
        //Key��Down�������̂݁A
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

        //���[���ɍ��킹�āA�ύX
        Destroy(_player);
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
    }
    void LaneLeft()
    {
        UnityEngine.Vector2 pos = PosBase.transform.position;
        pos[0] -= LaneWide;
        _player = Instantiate(ObjLeft, pos, PosBase.transform.rotation);
        //�v���C���[�̐ݒ�
        SpriteRenderer spr = _player.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneMiddle()
    {
        _player = Instantiate(ObjMiddle, PosBase.transform.position, PosBase.transform.rotation);
        //�v���C���[�̐ݒ�
        SpriteRenderer spr = _player.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }
    void LaneRight()
    {
        UnityEngine.Vector2 pos = PosBase.transform.position;
        pos[0] += LaneWide;
        _player = Instantiate(ObjRight, pos, PosBase.transform.rotation);
        //�v���C���[�̐ݒ�
        SpriteRenderer spr = _player.GetComponent<SpriteRenderer>();
        spr.sortingOrder = 1;
    }

    //�����蔻��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�������Ă���");
    }
}
