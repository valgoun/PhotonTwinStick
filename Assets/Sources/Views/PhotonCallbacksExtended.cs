using ExitGames.Client.Photon;
using Photon;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;



namespace TwinStick.Views
{
    /// <summary>
    /// Reactive Photon Callbacks extension
    /// I use lazy instantiation to minimize memory footprint when not all callbacks are used
    /// </summary>
    public class PhotonCallbacksExtended : PunBehaviour
    {

        public Subject<Unit> onConnectedToPhoton { get { return _onConnectedToPhoton != null ? _onConnectedToPhoton : _onConnectedToPhoton = new Subject<Unit>(); } }
        public Subject<Unit> onLeftRoom { get { return _onLeftRoom != null ? _onLeftRoom : _onLeftRoom = new Subject<Unit>(); } }
        public Subject<PhotonPlayer> onMasterClientSwitched { get { return _onMasterClientSwitched != null ? _onMasterClientSwitched : _onMasterClientSwitched = new Subject<PhotonPlayer>(); } }
        public Subject<object[]> onPhotonCreateRoomFailed { get { return _onPhotonCreateRoomFailed != null ? _onPhotonCreateRoomFailed : _onPhotonCreateRoomFailed = new Subject<object[]>(); } }
        public Subject<object[]> onPhotonJoinRoomFailed { get { return _onPhotonJoinRoomFailed != null ? _onPhotonJoinRoomFailed : _onPhotonJoinRoomFailed = new Subject<object[]>(); } }
        public Subject<Unit> onCreatedRoom { get { return _onCreatedRoom != null ? _onCreatedRoom : _onCreatedRoom = new Subject<Unit>(); } }
        public Subject<Unit> onJoinedLobby { get { return _onJoinedLobby != null ? _onJoinedLobby : _onJoinedLobby = new Subject<Unit>(); } }
        public Subject<Unit> onLeftLobby { get { return _onLeftLobby != null ? _onLeftLobby : _onLeftLobby = new Subject<Unit>(); } }
        public Subject<DisconnectCause> onFailedToConnectToPhoton { get { return _onFailedToConnectToPhoton != null ? _onFailedToConnectToPhoton : _onFailedToConnectToPhoton = new Subject<DisconnectCause>(); } }
        public Subject<Unit> onDisconnectedFromPhoton { get { return _onDisconnectedFromPhoton != null ? _onDisconnectedFromPhoton : _onDisconnectedFromPhoton = new Subject<Unit>(); } }
        public Subject<DisconnectCause> onConnectionFail { get { return _onConnectionFail != null ? _onConnectionFail : _onConnectionFail = new Subject<DisconnectCause>(); } }
        public Subject<PhotonMessageInfo> onPhotonInstantiate { get { return _onPhotonInstantiate != null ? _onPhotonInstantiate : _onPhotonInstantiate = new Subject<PhotonMessageInfo>(); } }
        public Subject<Unit> onReceivedRoomListUpdate { get { return _onReceivedRoomListUpdate != null ? _onReceivedRoomListUpdate : _onReceivedRoomListUpdate = new Subject<Unit>(); } }
        public Subject<Unit> onJoinedRoom { get { return _onJoinedRoom != null ? _onJoinedRoom : _onJoinedRoom = new Subject<Unit>(); } }
        public Subject<PhotonPlayer> onPhotonPlayerConnected { get { return _onPhotonPlayerConnected != null ? _onPhotonPlayerConnected : _onPhotonPlayerConnected = new Subject<PhotonPlayer>(); } }
        public Subject<PhotonPlayer> onPhotonPlayerDisconnected { get { return _onPhotonPlayerDisconnected != null ? _onPhotonPlayerDisconnected : _onPhotonPlayerDisconnected = new Subject<PhotonPlayer>(); } }
        public Subject<object[]> onPhotonRandomJoinFailed { get { return _onPhotonRandomJoinFailed != null ? _onPhotonRandomJoinFailed : _onPhotonRandomJoinFailed = new Subject<object[]>(); } }
        public Subject<Unit> onConnectedToMaster { get { return _onConnectedToMaster != null ? _onConnectedToMaster : _onConnectedToMaster = new Subject<Unit>(); } }
        public Subject<Unit> onPhotonMaxCccuReached { get { return _onPhotonMaxCccuReached != null ? _onPhotonMaxCccuReached : _onPhotonMaxCccuReached = new Subject<Unit>(); } }
        public Subject<Hashtable> onPhotonCustomRoomPropertiesChanged { get { return _onPhotonCustomRoomPropertiesChanged != null ? _onPhotonCustomRoomPropertiesChanged : _onPhotonCustomRoomPropertiesChanged = new Subject<Hashtable>(); } }
        public Subject<object[]> onPhotonPlayerPropertiesChanged { get { return _onPhotonPlayerPropertiesChanged != null ? _onPhotonPlayerPropertiesChanged : _onPhotonPlayerPropertiesChanged = new Subject<object[]>(); } }
        public Subject<Unit> onUpdatedFriendList { get { return _onUpdatedFriendList != null ? _onUpdatedFriendList : _onUpdatedFriendList = new Subject<Unit>(); } }
        public Subject<string> onCustomAuthenticationFailed { get { return _onCustomAuthenticationFailed != null ? _onCustomAuthenticationFailed : _onCustomAuthenticationFailed = new Subject<string>(); } }
        public Subject<Dictionary<string, object>> onCustomAuthenticationResponse { get { return _onCustomAuthenticationResponse != null ? _onCustomAuthenticationResponse : _onCustomAuthenticationResponse = new Subject<Dictionary<string, object>>(); } }
        public Subject<OperationResponse> onWebRpcResponse { get { return _onWebRpcResponse != null ? _onWebRpcResponse : _onWebRpcResponse = new Subject<OperationResponse>(); } }
        public Subject<object[]> onOwnershipRequest { get { return _onOwnershipRequest != null ? _onOwnershipRequest : _onOwnershipRequest = new Subject<object[]>(); } }
        public Subject<Unit> onLobbyStatisticsUpdate { get { return _onLobbyStatisticsUpdate != null ? _onLobbyStatisticsUpdate : _onLobbyStatisticsUpdate = new Subject<Unit>(); } }
        public Subject<PhotonPlayer> onPhotonPlayerActivityChanged { get { return _onPhotonPlayerActivityChanged != null ? _onPhotonPlayerActivityChanged : _onPhotonPlayerActivityChanged = new Subject<PhotonPlayer>(); } }
        public Subject<object[]> onOwnershipTransfered { get { return _onOwnershipTransfered != null ? _onOwnershipTransfered : _onOwnershipTransfered = new Subject<object[]>(); } }

        protected Subject<Unit> _onConnectedToPhoton;
        protected Subject<Unit> _onLeftRoom;
        protected Subject<PhotonPlayer> _onMasterClientSwitched;
        protected Subject<object[]> _onPhotonCreateRoomFailed;
        protected Subject<object[]> _onPhotonJoinRoomFailed;
        protected Subject<Unit> _onCreatedRoom;
        protected Subject<Unit> _onJoinedLobby;
        protected Subject<Unit> _onLeftLobby;
        protected Subject<DisconnectCause> _onFailedToConnectToPhoton;
        protected Subject<Unit> _onDisconnectedFromPhoton;
        protected Subject<DisconnectCause> _onConnectionFail;
        protected Subject<PhotonMessageInfo> _onPhotonInstantiate;
        protected Subject<Unit> _onReceivedRoomListUpdate;
        protected Subject<Unit> _onJoinedRoom;
        protected Subject<PhotonPlayer> _onPhotonPlayerConnected;
        protected Subject<PhotonPlayer> _onPhotonPlayerDisconnected;
        protected Subject<object[]> _onPhotonRandomJoinFailed;
        protected Subject<Unit> _onConnectedToMaster;
        protected Subject<Unit> _onPhotonMaxCccuReached;
        protected Subject<Hashtable> _onPhotonCustomRoomPropertiesChanged;
        protected Subject<object[]> _onPhotonPlayerPropertiesChanged;
        protected Subject<Unit> _onUpdatedFriendList;
        protected Subject<string> _onCustomAuthenticationFailed;
        protected Subject<Dictionary<string, object>> _onCustomAuthenticationResponse;
        protected Subject<OperationResponse> _onWebRpcResponse;
        protected Subject<object[]> _onOwnershipRequest;
        protected Subject<Unit> _onLobbyStatisticsUpdate;
        protected Subject<PhotonPlayer> _onPhotonPlayerActivityChanged;
        protected Subject<object[]> _onOwnershipTransfered;

        public override void OnConnectedToPhoton() => _onConnectedToMaster?.OnNext(Unit.Default);
        public override void OnLeftRoom() => _onLeftRoom?.OnNext(Unit.Default);
        public override void OnMasterClientSwitched(PhotonPlayer newMasterClient) => _onMasterClientSwitched?.OnNext(newMasterClient);
        public override void OnPhotonCreateRoomFailed(object[] codeAndMsg) => _onPhotonCreateRoomFailed?.OnNext(codeAndMsg);
        public override void OnPhotonJoinRoomFailed(object[] codeAndMsg) => _onPhotonJoinRoomFailed?.OnNext(codeAndMsg);
        public override void OnCreatedRoom() => _onCreatedRoom?.OnNext(Unit.Default);
        public override void OnJoinedLobby() => _onJoinedLobby?.OnNext(Unit.Default);
        public override void OnLeftLobby() => _onLeftLobby?.OnNext(Unit.Default);
        public override void OnFailedToConnectToPhoton(DisconnectCause cause) => _onFailedToConnectToPhoton?.OnNext(cause);
        public override void OnDisconnectedFromPhoton() => _onDisconnectedFromPhoton?.OnNext(Unit.Default);
        public override void OnConnectionFail(DisconnectCause cause) => _onConnectionFail?.OnNext(Unit.Default);
        public override void OnPhotonInstantiate(PhotonMessageInfo info) => _onPhotonInstantiate?.OnNext(Unit.Default);
        public override void OnReceivedRoomListUpdate() => _onReceivedRoomListUpdate?.OnNext();
        public override void OnJoinedRoom() => _onJoinedRoom?.OnNext();
        public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer) => _onPhotonPlayerConnected?.OnNext(newPlayer);
        public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) => _onPhotonPlayerDisconnected?.OnNext(otherPlayer);
        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg) => _onPhotonRandomJoinFailed?.OnNext(codeAndMsg);
        public override void OnConnectedToMaster() => _onConnectedToMaster?.OnNext();
        public override void OnPhotonMaxCccuReached() => _onPhotonMaxCccuReached?.OnNext();
        public override void OnPhotonCustomRoomPropertiesChanged(Hashtable propertiesThatChanged) => _onPhotonCustomRoomPropertiesChanged?.OnNext(propertiesThatChanged);
        public override void OnPhotonPlayerPropertiesChanged(object[] playerAndUpdatedProps) => _onPhotonPlayerPropertiesChanged?.OnNext(playerAndUpdatedProps);
        public override void OnUpdatedFriendList() => _onUpdatedFriendList?.OnNext();
        public override void OnCustomAuthenticationFailed(string debugMessage) => _onCustomAuthenticationFailed?.OnNext(debugMessage);
        public override void OnCustomAuthenticationResponse(Dictionary<string, object> data) => _onCustomAuthenticationResponse?.OnNext(data);
        public override void OnWebRpcResponse(OperationResponse response) => _onWebRpcResponse?.OnNext(response);
        public override void OnOwnershipRequest(object[] viewAndPlayer) => _onOwnershipRequest?.OnNext(viewAndPlayer);
        public override void OnLobbyStatisticsUpdate() => _onLobbyStatisticsUpdate?.OnNext();
        public override void OnPhotonPlayerActivityChanged(PhotonPlayer otherPlayer) => _onPhotonPlayerActivityChanged?.OnNext(otherPlayer);
        public override void OnOwnershipTransfered(object[] viewAndPlayers) => _onOwnershipTransfered?.OnNext(viewAndPlayers);


    }
}