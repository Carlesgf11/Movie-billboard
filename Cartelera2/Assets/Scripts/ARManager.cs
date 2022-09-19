using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARManager : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    AudioSource audioSource;

    private void Awake()
    {
        UnityEngine.XR.XRSettings.enabled = true;
    }

    private void Start()
    {
        //audioSource.GetComponent<AudioSource>();
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

    public void LoadInfo(Movie _movie)
    {
        GameManager.Instance.movie = _movie;
        GameManager.Instance.currenActor = _movie.staff[0];

        //audioSource.PlayOneShot(clip);
        ChangeScene(2);
    }
}
