using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Registry.Instance.refrences.player.animationController.animator.SetTrigger("stumble");
            StartCoroutine(Recover());
        }
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(0.8f);
        Registry.Instance.refrences.player.currentCharacter.transform.localEulerAngles = new Vector3();
        Registry.Instance.refrences.player.animationController.SetAnimation(Registry.Instance.refrences.player.animationController.currentAnim);
    }
}
