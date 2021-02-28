using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public Button        startButton = null;
    public TMP_Text      statusText = null;
    public TMP_Dropdown  spielerDropdown = null;

    // Start is called before the first frame update
    void Start()
    {
       statusText.text = "Verbinde ...";
       PhotonNetwork.ConnectUsingSettings();
       startButton.gameObject.SetActive( false);
       Debug.Log( "Vrooom");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log( "Ping");
    	  base.OnConnectedToMaster();

        PhotonNetwork.AutomaticallySyncScene = true;
        statusText.text = "Verbunden mit " +  PhotonNetwork.ServerAddress;
	     startButton.gameObject.SetActive( true);
    }

    public override void OnJoinedRoom()
    {
     	  base.OnJoinedRoom();

        Debug.Log( "Joined");
        SceneManager.LoadScene( "Game");
        Debug.Log( "Clicky click");
     }


    public void startButton_Click()
    {
       string   name;
       int      index;

       statusText.text = "Lade";

       index = spielerDropdown.value;
       name  = spielerDropdown.options[ index].text;

       PhotonNetwork.LocalPlayer.NickName = name;

       Debug.Log( "Spieler #" + index + " : " + name);
       Photon.Realtime.RoomOptions   opts = new Photon.Realtime.RoomOptions();
       opts.IsOpen     = true;
       opts.IsVisible  = true;
       opts.MaxPlayers = 10;

       PhotonNetwork.JoinOrCreateRoom( "Flobby", opts, Photon.Realtime.TypedLobby.Default);
    }
 }

