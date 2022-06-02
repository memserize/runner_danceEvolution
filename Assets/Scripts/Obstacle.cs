using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{


    float distanceToPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if (Registry.Instance.refrences.gameManager.hitObstacleCount < 3)
            {
                Registry.Instance.refrences.player.animationController.animator.SetTrigger("stumble");
                Registry.Instance.refrences.gameManager.hitObstacleCount++;
                StartCoroutine(Recover());
            }
            else if (Registry.Instance.refrences.gameManager.hitObstacleCount == 3)
            {
                Registry.Instance.refrences.player.animationController.animator.SetTrigger("fall");
                Registry.Instance.refrences.player.movementController.initialized = false;

                for (int i = 0; i < Registry.Instance.refrences.player.playerCharacters.Count; i++)
                {
                    Registry.Instance.refrences.player.playerCharacters[i].lockTransforms = false;
                }
            }

        }
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(0.8f);
        Registry.Instance.refrences.player.currentCharacter.transform.localEulerAngles = new Vector3();
        Registry.Instance.refrences.player.animationController.SetAnimation(Registry.Instance.refrences.player.animationController.currentAnim);
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(Registry.Instance.refrences.player.transform.position, transform.position);


        if (distanceToPlayer > 0 && distanceToPlayer < 20)
        {
           transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
