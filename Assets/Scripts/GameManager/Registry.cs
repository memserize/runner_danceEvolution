using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using AppAdvisory.SharingSystem;
using DG.Tweening;

public class Registry : MonoBehaviour
{

    public Refrences refrences;

    private static Registry _instance;

    public static Registry Instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("There are duplicate Logic Managers in the Scene");
            Debug.Break();
        }
        Instance = this;
    }


    public void TakeCrewPhoto()
    {
        refrences.takeAndShowScreenshot.OnClicked();
        //refrences.vShare.OnClickedOnIconScreenshot();
        StartCoroutine(photoWait());
    }

    public IEnumerator photoWait()
    {
        yield return new WaitForSeconds(0.63f);
        refrences.vShare.OnClickedOnIconScreenshot();
    }



}

[System.Serializable]
public class Refrences
{
    [Title("Core")]
    public GameManager gameManager;
    public CrowdManager crowdManager;
    public Transform levelEnd;

    [Title("Player")]
    public PlayerRefrenceManager player;


    [Title("ScreenShot")]
    public TakeAndShowScreenshotFromScript takeAndShowScreenshot;
    public VSSHARE vShare;



}
