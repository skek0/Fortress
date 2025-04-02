using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Watch : MonoBehaviourPun
{
    Text timeText;
    double time;
    double initTime;

    int minute;
    int second;
    int milisec;

    private void Awake()
    {
        timeText = GetComponent<Text>();
        initTime = PhotonNetwork.Time;
    }

    private void Update()
    { 
        time = PhotonNetwork.Time - initTime;

        minute = (int)time / 60;
        second = (int)time % 60;
        milisec = (int)(time * 100) % 100;

        timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, milisec);
    }
}
