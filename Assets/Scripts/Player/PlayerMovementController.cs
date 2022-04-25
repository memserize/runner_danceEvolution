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
    public float xMin;
    public float xMax;

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
            Mathf.Clamp(curPosition.x, 0, 0);

            characterTransform.localPosition = new Vector3(Mathf.Clamp(curPosition.x, xMin, xMax), 0, 0 );
        }

    }
}
