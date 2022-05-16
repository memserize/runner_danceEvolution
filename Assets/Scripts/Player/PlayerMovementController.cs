using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerMovementController : MonoBehaviour
{

    public bool initialized;

    [Space]
    public Transform characterTransform;

    [Space]
    public float forwardMovementSpeed;
    public float xMin;
    public float xMax;

    [Space]
    public float distanceToLevelEnd;

    [Space]
    public Vector3 cameraOffset;

    private Vector3 screenPoint;
    private Vector3 offset;


    private void Start()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = characterTransform.localPosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }


    public void Initalize()
    {
        initialized = true;
    }


    void Update()
    {
        if(initialized)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            Mathf.Clamp(curPosition.x, xMin, xMax);
            Mathf.Clamp(curPosition.y, 0, 0);

            transform.position = new Vector3(Mathf.Clamp(curPosition.x, xMin, xMax), 0, transform.position.z + (forwardMovementSpeed * Time.deltaTime));
            Camera.main.transform.position = new Vector3(0, cameraOffset.y, transform.position.z + (forwardMovementSpeed * Time.deltaTime) + cameraOffset.z);

            distanceToLevelEnd = Vector3.Distance(Registry.Instance.refrences.levelEnd.position, transform.position);

            if (distanceToLevelEnd < 1)
            {
                initialized = false;
                Registry.Instance.refrences.player.animationController.SetAnimation("idle");

            }

        }

    }
}
