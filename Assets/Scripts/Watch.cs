using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Watch : MonoBehaviourPun
{
    Text timeText;
    float time;

    private void Awake()
    {
        timeText = GetComponent<Text>();
    }

    private void Update()
    {
        time = (float)PhotonNetwork.Time;
        string.Format(timeText.text, time);
    }
}
