using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

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



}
