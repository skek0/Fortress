using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputfield;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Transform parentTransform;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputfield.ActivateInputField();

            if (inputfield.text.Length <= 0) return;

            // RPC Target.All : 현재 홈에 있는 모든 클라이언트에게 Talk() 함수를
            // 실행하라는 명령을 전달
            // Remote Procedure Call
            photonView.RPC("Talk", RpcTarget.All, inputfield.text);
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        // Prefab을 하나 생성한 다음 text 값을 설정
        GameObject talk = Instantiate(Resources.Load<GameObject>("Talk"));

        // prefab 오브젝트의 Text 컴포넌트로 접근해서 text의 값을 설정합니다.
        talk.GetComponent<Text>().text = message;

        // 스크롤 뷰 - content 오브젝트의 자식으로 등록
        talk.transform.SetParent(parentTransform);

        // 채팅을 입력한 후에도 이어서 입력할 수 있도록 설정
        inputfield.ActivateInputField();

        Canvas.ForceUpdateCanvases();

        // 스크롤의 위치를 초기화
        scrollRect.verticalNormalizedPosition = 0.0f;

        // inputField의 텍스트를 초기화
        inputfield.text = null;
    }
}
