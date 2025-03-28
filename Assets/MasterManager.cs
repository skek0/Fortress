using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterManager : MonoBehaviourPunCallbacks
{
    WaitForSeconds waitforSeconds = new WaitForSeconds(5f);
    Vector3[] energyPos = new Vector3[4];

    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(CreateEnergy());
        }
    }

    IEnumerator CreateEnergy()
    {
        while(true)
        {
            PhotonNetwork.Instantiate("Energy", Vector3.zero, Quaternion.identity);
            yield return waitforSeconds;
        }
    }

    
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        StartCoroutine(CreateEnergy());
    }

}
