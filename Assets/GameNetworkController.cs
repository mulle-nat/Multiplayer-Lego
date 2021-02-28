using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;


public class GameNetworkController : MonoBehaviourPunCallbacks
{
    public CinemachineFreeLook   freeLookCamera = null;

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

       GameObject player = PhotonNetwork.Instantiate( "Spieler", position, rotation);
       if( ! player)
       {
          Debug.Log( "Did not get a player instantiated");
          return;
       }
       if( ! freeLookCamera)
       {
          Debug.Log( "Did not get a camera hooked up in the editor");
          return;
       }
       
       freeLookCamera.Follow = player.transform;
       freeLookCamera.LookAt = player.transform;
    }
}

