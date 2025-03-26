using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField]InputField inputfield;

    public void SaveNickName()
    {
        PlayerPrefs.SetString("Name", inputfield.text);

        PhotonNetwork.NickName = inputfield.text;

        gameObject.SetActive(false);
    }
}
