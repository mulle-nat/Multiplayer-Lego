using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GameNetworkController : MonoBehaviourPunCallbacks
{
    private void  Awake()
    {
       Vector3      position;
       GameObject   spawn;
       Quaternion   rotation;
       
       position = new Vector3( 241.92f, 1.0f, -42.6f); // default, aber falsch
       rotation = Quaternion.identity; 
       Debug.Log( "Nickname: \"" + PhotonNetwork.LocalPlayer.NickName + "\"");
       spawn    = GameObject.Find( PhotonNetwork.LocalPlayer.NickName); 
       if( spawn)
       {
          position = spawn.transform.position;
          rotation = spawn.transform.rotation;
       }
       PhotonNetwork.Instantiate( "Spieler", position, rotation);
    }
}

