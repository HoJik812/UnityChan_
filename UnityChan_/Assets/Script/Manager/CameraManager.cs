using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{

    public Camera[] cameras;

    public void CheckCamera()
    {
        Debug.Log("ī�޶� üũ");
        for (int i = 1; i < CameraManager.Instance.cameras.Length; i++)//���ξ� ī�޶� 0������ �ּ� ���ξ� ���� ī�޶� ���� off => ���ξ����� ���ư�
        {
            CameraManager.Instance.cameras[i].gameObject.SetActive(false);
        }
    }

}
