using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class NickName : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        Information(null);
    }
    private void Information(LoginResult result)
    {
        //�α��� ���� ��, ������ ���� ���� ��û
        GetAccountInfoRequest accountInfoRequest = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(accountInfoRequest, Success, Failure);
    }

    private void Success(GetAccountInfoResult result)
    {
        // ������ DisplayName ���
        photonView.Owner.NickName = result.AccountInfo.Username; // �Ǵ� result.AccessInfo.TitleInfo.DisplayName

        Debug.Log(result.AccountInfo.Username);
        Debug.Log(photonView.Owner.NickName);
    }

    private void Failure(PlayFabError error)
    {
        Debug.LogError("Error : " + error.GenerateErrorReport());
    }
}
