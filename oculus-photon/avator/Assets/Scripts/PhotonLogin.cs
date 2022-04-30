using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Hakoniwa.Plugin.Photon
{
    public class PhotonLogin : MonoBehaviourPunCallbacks
    {
        public string name = "hako_avator";

        // Use this for initialization
        void Start()
        {
            //Debug.Log("Start!!!");
            PhotonNetwork.ConnectUsingSettings();
        }
        void OnGUI()
        {
            //Debug.Log("OnGUI!!!");
            //ログインの状態を画面上に出力
            GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
        }
        //ルームに入室前に呼び出される
        public override void OnConnectedToMaster()
        {
            //Debug.Log("OnConnectedToMaster!!!");
            // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
            PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
        }
        public override void OnJoinedLobby()
        {

        }
        public override void OnJoinedRoom()
        {

            Debug.Log("OnJoinedRoom!!!");
            Vector3 pos = new Vector3(0, 1, 0);
            var instance = PhotonNetwork.Instantiate("HakoAvator", pos, Quaternion.identity);
            instance.name = this.name;

        }
    }
}
