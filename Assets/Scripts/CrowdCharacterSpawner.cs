using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CrowdCharacterSpawner : MonoBehaviour
{
    public bool initialized;
    public bool spawnOnStart;

    [Space]
    public float distanceToPlayer;
    public Vector2 toggleDistance;

    [Space]
    public GameObject previewMesh;
    public Transform spawnTransform;

    [Space]
    public CrowdCharacter crowdCharacter;
    public CrowdCharacter[] crowdCharacters;

    private void Start()
    {
        if (spawnOnStart)
        {
            SpawnCharacter();
        }

        previewMesh.SetActive(false);

    }


    public void SpawnCharacter()
    {
        crowdCharacter = Instantiate(crowdCharacters[Random.Range(0, crowdCharacters.Length)], spawnTransform.position, spawnTransform.rotation, transform);
        crowdCharacter.index = Registry.Instance.refrences.player.currentCharacterIndex;
        crowdCharacter.UpdateCharacter(false);
        initialized = true;
    }


    private void Update()
    {
        if(initialized)
        {
            distanceToPlayer = Vector3.Distance(Registry.Instance.refrences.player.transform.position, transform.position);


            if (distanceToPlayer > toggleDistance.x && distanceToPlayer < toggleDistance.y)
            {
                crowdCharacter.gameObject.SetActive(true);
            }
            else
            {
                crowdCharacter.gameObject.SetActive(false);
            }


            Quaternion targetRotation = Quaternion.LookRotation(Registry.Instance.refrences.player.transform.position - transform.position);
            float str = Mathf.Min(5 * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}
