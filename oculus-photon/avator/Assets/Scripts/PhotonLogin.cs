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
            //���O�C���̏�Ԃ���ʏ�ɏo��
            GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
        }
        //���[���ɓ����O�ɌĂяo�����
        public override void OnConnectedToMaster()
        {
            //Debug.Log("OnConnectedToMaster!!!");
            // "room"�Ƃ������O�̃��[���ɎQ������i���[����������΍쐬���Ă���Q������j
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
