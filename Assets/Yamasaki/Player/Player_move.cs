using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx= Input.GetAxis("Horizontal") ;
        float x = 0.0F;
        x = dx * 0.1f;
        transform.Translate(x, 0.0F, 0, 0F);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("“–‚½‚Á‚Ä‚¢‚é");
    }
}
