using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    PlayerManager _playerManager;
    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame

    //�����蔻��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == _tagObstancle)
        //{
        Debug.Log("�������Ă����");
        _playerManager._health -= 1;
        //}

    }
}
