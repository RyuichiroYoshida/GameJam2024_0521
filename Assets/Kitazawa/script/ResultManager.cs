using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField] UIManager _uiManager = null;
    [SerializeField] InGameManager _inGame = null;

    // Update is called once per frame
    public void GmUpdate()
    {
        //�ق����\�b�h����
        _uiManager.ResultText(_inGame.Gm_score);
    }
}
