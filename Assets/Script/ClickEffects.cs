using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffects : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 objPosition;
    [SerializeField] GameObject particle;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Instantiate(particle, objPosition, Quaternion.identity);
        }
    }
}