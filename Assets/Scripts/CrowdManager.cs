using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CrowdManager : MonoBehaviour
{
    [Title("CrowdAnimators")]
    public Animator[] crowdAnimators;

    [Space]
    public List<CrowdCharacterSpawner> crowdCharacterSpawners = new List<CrowdCharacterSpawner>();

    public void Initialize()
    {
        for (int i = 0; i < crowdCharacterSpawners.Count; i++)
        {
            crowdCharacterSpawners[i].SpawnCharacter();
        }

    }


    public void UpdateCharacters()
    {
        for (int i = 0; i < crowdCharacterSpawners.Count; i++)
        {
            crowdCharacterSpawners[i].crowdCharacter.index = Registry.Instance.refrences.player.currentCharacterIndex -1;
            crowdCharacterSpawners[i].crowdCharacter.ChangeCharacter();
        }
    }



    [Button]
    void Editor_AssignCrowdSpawners()
    {
        if(crowdCharacterSpawners.Count > 0)
        {
            crowdCharacterSpawners.Clear();
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            crowdCharacterSpawners.Add(transform.GetChild(i).GetComponent<CrowdCharacterSpawner>());
        }
    }
}
