using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCharacterSpawner : MonoBehaviour
{
    public bool initialized;
    public bool spawnOnStart;


    [Space]
    public GameObject previewMesh;
    public Transform spawnTransform;

    [Space]
    public CollectableCharacter character;
    public CollectableCharacter[] crowdCharacters;

    PlayerRefrenceManager player;

    private void Start()
    {
        if (spawnOnStart)
        {
            SpawnCharacter();
        }

        previewMesh.SetActive(false);

        player = Registry.Instance.refrences.player;

    }


    public void SpawnCharacter()
    {
        character = Instantiate(crowdCharacters[Random.Range(0, crowdCharacters.Length)], spawnTransform.position, spawnTransform.rotation, transform);
        character.index = Registry.Instance.refrences.player.currentCharacterIndex;
        character.UpdateCharacter(false);
        initialized = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            character.transform.parent = player.characterSlotTransforms[player.characterSlotIndex].transform;
            player.characterSlotIndex++;
            character.transform.localPosition = new Vector3();
            player.collectedCharacters.Add(character);
            gameObject.SetActive(false);
        }
    }

}
