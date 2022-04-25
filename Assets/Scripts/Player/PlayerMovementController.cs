using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    [Space]
    public float yClampMin;
    public float yClampMax;

    [Space]
    public float xClampMin;
    public float xClampMax;

    [Space]
    public float zClampMin;
    public float zClampMax;


    void Start()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void Update()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        Mathf.Clamp(curPosition.x, xClampMin, xClampMax);
        Mathf.Clamp(curPosition.y, yClampMin, yClampMax);
        Mathf.Clamp(curPosition.x, zClampMin, zClampMax);

        transform.position = new Vector3(Mathf.Clamp(curPosition.x, xClampMin, xClampMax), Mathf.Clamp(curPosition.y, yClampMin, yClampMax), Mathf.Clamp(curPosition.z, zClampMin, zClampMax));

    }
}
