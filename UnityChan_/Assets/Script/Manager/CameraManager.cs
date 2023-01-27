using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{

    public Camera[] cameras;

    public void CheckCamera()
    {
        Debug.Log("카메라 체크");
        for (int i = 1; i < CameraManager.Instance.cameras.Length; i++)//메인씬 카메라를 0번으로 둬서 메인씬 외의 카메라를 전부 off => 메인씬으로 돌아감
        {
            CameraManager.Instance.cameras[i].gameObject.SetActive(false);
        }
    }

}
