using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollider : MonoBehaviour
{
    private bool detector;

    public bool Detector
    {
        get { return detector; }
    }
    private void OnTriggerStay(Collider other)
    {
        CollisionObject vehicle = other.GetComponent<CollisionObject>();

        if (vehicle != null)
        {
            Debug.Log("Right Collider Stay");
            detector = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CollisionObject vehicle = other.GetComponent<CollisionObject>();

        if (vehicle != null)
        {
            Debug.Log("Right Collider Exit");
            detector = false;
        }
    }
}
