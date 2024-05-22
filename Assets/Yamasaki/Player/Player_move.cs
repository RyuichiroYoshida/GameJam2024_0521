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

    //“–‚½‚è”»’è
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == _tagObstancle)
        //{
        Debug.Log("“–‚½‚Á‚Ä‚¢‚é‚æ");
        _playerManager._health -= 1;
        //}

    }
}
