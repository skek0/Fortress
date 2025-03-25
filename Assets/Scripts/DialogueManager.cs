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

            // RPC Target.All : ���� Ȩ�� �ִ� ��� Ŭ���̾�Ʈ���� Talk() �Լ���
            // �����϶�� ����� ����
            // Remote Procedure Call
            photonView.RPC("Talk", RpcTarget.All, inputfield.text);
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        // Prefab�� �ϳ� ������ ���� text ���� ����
        GameObject talk = Instantiate(Resources.Load<GameObject>("Talk"));

        // prefab ������Ʈ�� Text ������Ʈ�� �����ؼ� text�� ���� �����մϴ�.
        talk.GetComponent<Text>().text = message;

        // ��ũ�� �� - content ������Ʈ�� �ڽ����� ���
        talk.transform.SetParent(parentTransform);

        // ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� ����
        inputfield.ActivateInputField();

        Canvas.ForceUpdateCanvases();

        // ��ũ���� ��ġ�� �ʱ�ȭ
        scrollRect.verticalNormalizedPosition = 0.0f;

        // inputField�� �ؽ�Ʈ�� �ʱ�ȭ
        inputfield.text = null;
    }
}
