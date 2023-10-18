using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Photon.Pun;

public class ChatBox : MonoBehaviourPun
{
    public TextMeshProUGUI chatLogText;
    public TMP_InputField chatInput;

    // instance
    public static ChatBox instance;

    void Awake()
    { 
        instance = this;
    }

    // called when the player wants to send a message
    public void OnChatInputSend()
    { 
        if(chatInput.text.Length > 0) 
        {
            photonView.RPC("Log", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, chatInput.text);
            chatInput.text = "";
        }

        EventSystem.current.SetSelectedGameObject(null);
    }
}
