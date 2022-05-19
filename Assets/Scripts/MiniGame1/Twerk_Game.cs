using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Twerk_Game : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private Vector3 playerTwerkSpot = new Vector3(1, 0, 61.85f);
    private Vector3 enemyTwerkSpot = new Vector3(-1, -0.679f, 61.85f);

    public GameObject meter;
    public Animator enemyAnims;

    private bool isTwerking;

    public ParticleSystem confettiTwerk;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTwerking)
        {
            StartCoroutine(TwerkTimerPlayer());
            StartCoroutine(TwerkTimerEnemy());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Minigame1")
        {
            //player.GetComponent<PlayerMovementController>().forwardMovementSpeed = 0;
            player.GetComponent<PlayerMovementController>().initialized = false;
            player.transform.DOMove(playerTwerkSpot, 2f).OnComplete(StandOffPlayer);
            Registry.Instance.refrences.player.animationController.animator.SetTrigger("walking");
            enemy.transform.DOMove(enemyTwerkSpot, 2f).OnComplete(StandOffEnemy);

            //Registry.Instance.refrences.player.animationController.animator.SetTrigger("twerking");

            //Registry.Instance.refrences.player.animationController.animator.SetTrigger(Registry.Instance.refrences.player.animationController.currentAnim);
        }
    }

    public void StandOffPlayer()
    {
        Registry.Instance.refrences.player.animationController.animator.SetTrigger("idle");
        player.transform.DORotate(new Vector3(0, -90, 0), 0.5f).OnComplete(MeterMovement);
    }

    public void StandOffEnemy()
    {
        enemyAnims.SetTrigger("idle");
        enemy.transform.DORotate(new Vector3(0, 90, 0), 0.5f);
    }

    public void TwerkingTrue()
    {
        isTwerking = true;
    }
    public void RotateToTwerkPlayer()
    {
        player.transform.DORotate(new Vector3(0, 135f, 0), 1f).OnComplete(TwerkingTrue);
    }

    public void RotateToTwerkEnemy()
    {
        enemy.transform.DORotate(new Vector3(0, -135f, 0), 1f);
        print("rotate enemy twerk");
    }

    public void MeterMovement()
    {
        meter.SetActive(true);
        StartCoroutine(StartDancing());
    }

    public IEnumerator StartDancing()
    {
        yield return new WaitForSeconds(3.5f);
        RotateToTwerkPlayer();
        RotateToTwerkEnemy();
        meter.SetActive(false);

    }

    public IEnumerator TwerkTimerPlayer()
    {
        isTwerking = false;
        //meter.SetActive(true);
        Registry.Instance.refrences.player.animationController.animator.SetTrigger("twerking");
        yield return new WaitForSeconds(10f);
        //meter.SetActive(false);
        Registry.Instance.refrences.player.animationController.animator.SetTrigger(Registry.Instance.refrences.player.animationController.currentAnim);
        //player.GetComponent<PlayerMovementController>().forwardMovementSpeed = 1.2f;
        player.transform.DORotate(new Vector3(0, 0, 0), 0.5f);
        confettiTwerk.Play();
        player.GetComponent<PlayerMovementController>().initialized = true;
    }

    public IEnumerator TwerkTimerEnemy()
    {
        enemyAnims.SetTrigger("twerking");
        yield return new WaitForSeconds(5f);
        enemyAnims.SetTrigger("upset");
        yield return new WaitForSeconds(5f);
        enemyAnims.SetTrigger("sad_walk");

        enemy.transform.DORotate(new Vector3(0, -90, 0), 0.5f);
        enemy.transform.DOMoveX(-5.5f, 6f).OnComplete(EnemyDisable);
    }

    public void EnemyDisable()
    {
        enemy.SetActive(false);
    }
}
