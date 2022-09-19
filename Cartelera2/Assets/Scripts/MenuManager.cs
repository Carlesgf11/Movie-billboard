using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    private void Awake()
    {
        UnityEngine.XR.XRSettings.enabled = false;
    }

    public void SetLenguage(int lenguage) //0 espanol 1 ingles
    {
        GameManager.Instance.SetAppLenguage(lenguage);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }

    public void ChangeScene(int indexBuild)
    {
        StartCoroutine(DelayToChangeScene(indexBuild));
    }

    IEnumerator DelayToChangeScene(int indexBuild)
    {
        yield return new WaitForSeconds(Constants.DELAY_BETWEN_SCENES);
        GameManager.Instance.ChangeScene(indexBuild);
    }
}
