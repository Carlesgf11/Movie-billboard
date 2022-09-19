using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class InfoManager : MonoBehaviour
{
    [SerializeField] Actor prevActor, nextActor;
    [SerializeField] Button btnInfoMovie, btnInfoActor, btnPrevActor, btnNextActor;

    #region Movies
    [SerializeField] Text title, sinopsys, year;
    [SerializeField] Image cover, movieFlag;
    #endregion

    #region Actors
    [SerializeField] Text nameActor, bioActor;
    [SerializeField] Image portrait, actorFlag;
    [SerializeField] Text sexActor;
    #endregion

    private int indexActor;

    private void Awake()
    {
        UnityEngine.XR.XRSettings.enabled = false;
    }

    private void Start()
    {
        indexActor = 0;
        SetPrevNext();
    }
    
    private void ShowInfo()
    {
        title.text = GameManager.Instance.movie.title[(int)GameManager.Instance.Lenguaje];
        sinopsys.text = GameManager.Instance.movie.sinopsis[(int)GameManager.Instance.Lenguaje];
        year.text = GameManager.Instance.movie.year.ToString();
        cover.sprite = GameManager.Instance.movie.cover;
        movieFlag.sprite = GameManager.Instance.movie.countryFlag;
        //btnInfoMovie.image.sprite = GameManager.Instance.movie.cover;

        //btnInfoActor.image.sprite = GameManager.Instance.currenActor.portrait;
        portrait.sprite = GameManager.Instance.currenActor.portrait;

        nameActor.text = GameManager.Instance.currenActor.actorName;
        bioActor.text = GameManager.Instance.currenActor.biography[(int)GameManager.Instance.Lenguaje];
        actorFlag.sprite = GameManager.Instance.currenActor.countryFlag;

        switch (GameManager.Instance.Lenguaje)
        {
            case 0:
                if (GameManager.Instance.currenActor.sex)
                    sexActor.text = "Actiz";
                else
                    sexActor.text = "Actor";
                break;
            case 1:
                if (GameManager.Instance.currenActor.sex)
                    sexActor.text = "Actress";
                else
                    sexActor.text = "Actor";
                break;
            //default:
            //    sexActor.text = "Actor";
            //    break;
        }
    }

    private void SetPrevNext()
    {
        int indexPrev = indexActor - 1;
        int indexNext = indexActor + 1;

        if (indexPrev < 0)
            indexPrev = GameManager.Instance.movie.staff.Length - 1;
        if (indexNext >= GameManager.Instance.movie.staff.Length)
            indexNext = 0;

        nextActor = GameManager.Instance.movie.staff[indexNext];
        prevActor = GameManager.Instance.movie.staff[indexPrev];

        GameManager.Instance.currenActor = GameManager.Instance.movie.staff[indexActor];

        ShowInfo();
    }

    public void SetNext()
    {
        indexActor++;
        if (indexActor >= GameManager.Instance.movie.staff.Length)
            indexActor = 0;
        SetPrevNext();
    }
    public void SetPrev()
    {
        indexActor--;
        if (indexActor < 0)
            indexActor = GameManager.Instance.movie.staff.Length - 1;
        SetPrevNext();
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
