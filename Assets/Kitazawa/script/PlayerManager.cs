using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerLaneState
{
    Left,
    Middle,
    Right
}
public class PlayerManager : MonoBehaviour
{
    //�p�����[�^�[
    [SerializeField] GameObject PlayerLeft;
    [SerializeField] GameObject PlayerMiddle;
    [SerializeField] GameObject PlayerRight;
    public PlayerLaneState PlayLane;

    //�ϐ��̒�`
    //bool keyDown_Hrzn = false;
    //float last_KeyDown_Hrzn;
    void GM_Start()
    {
        
    }

    //
    public void GM_Update()
    {
        //Key��Down�������̂݁A
        if (Input.GetKeyDown(KeyCode.D))//�E
        {
            PlayLane += 1;//���[����ύX
        }
        if (Input.GetKeyDown(KeyCode.A))//��
        {
            PlayLane -= 1;//���[����ύX
        }

        //���[���ɍ��킹�āA�ύX
        switch (PlayLane)
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
        void LaneLeft()
        {

        }
        void LaneMiddle()
        { 

        }
        void LaneRight()
        {

        }
    }

    //�����蔻��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�������Ă���");
    }
}
