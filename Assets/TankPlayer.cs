using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tanks
{
    public class TankPlayer : MonoBehaviourPunCallbacks
    {
        private Complete.TankMovement m_Movement;
        // Reference to tank's shooting script, used to disable and enable control.
        private Complete.TankShooting m_Shooting;
        // Start is called before the first frame update
        private void Awake()
        {
            m_Movement = GetComponent<Complete.TankMovement>();
            m_Shooting = GetComponent<Complete.TankShooting>();
            if (!photonView.IsMine)
            {
                m_Movement.enabled = false;
                m_Shooting.enabled = false;
                enabled = false;
            }
        }
    }

    
}


