using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Twerk_Game : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private Vector3 playerTwerkSpot = new Vector3(1, 0, 61.85f);
    private Vector3 enemyTwerkSpot = new Vector3(-1, 0, 61.85f);

    public GameObject sliderPin;
    public Animator enemyAnims;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Minigame1")
        {
            player.GetComponent<PlayerMovementController>().forwardMovementSpeed = 0;
            player.transform.DOMove(playerTwerkSpot, 2f).OnComplete(RotateToTwerkPlayer);
            enemy.transform.DOMove(enemyTwerkSpot, 2f).OnComplete(RotateToTwerkEnemy);

            Registry.Instance.refrences.player.animationController.animator.SetTrigger("twerking");

            //Registry.Instance.refrences.player.animationController.animator.SetTrigger(Registry.Instance.refrences.player.animationController.currentAnim);
        }
    }

    public void RotateToTwerkPlayer()
    {
        player.transform.DORotate(new Vector3(0, 135f, 0), 1f);
    }

    public void RotateToTwerkEnemy()
    {
        player.transform.DORotate(new Vector3(0, -135f, 0), 1f);
    }

    public void RotateSlider()
    {
        sliderPin.transform.DORotate(new Vector3(0, 0, 50f), 0.5f).SetLoops(10);
    }

    public IEnumerator TwerkTimerPlayer()
    {
        Registry.Instance.refrences.player.animationController.animator.SetTrigger("twerking");
        yield return new WaitForSeconds(10f);
        Registry.Instance.refrences.player.animationController.animator.SetTrigger(Registry.Instance.refrences.player.animationController.currentAnim);
        player.GetComponent<PlayerMovementController>().forwardMovementSpeed = 1.2f;
    }

    public IEnumerator TwerkTimerEnemy()
    {
        enemyAnims.SetTrigger("twerking");
        yield return new WaitForSeconds(10f);
        enemyAnims.SetTrigger("upset");
    }
}
