using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretRotate : MonoBehaviourPunCallbacks
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
           
           this.transform.Rotate(0,0.1f*speed,0);
            Debug.Log("aa");
        }
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("bb");
            this.transform.Rotate (0, -0.1f *speed ,0);
        }
    }
}
