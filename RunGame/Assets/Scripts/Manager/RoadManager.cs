using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roadList;
    [SerializeField] List<GameObject> newRoad;
    [SerializeField] float speed = 5.0f;

    float newZ = 48.6f;

    public Vector3 targetPosition = new Vector3(0, 0, 48.3f);
    

    void Start()
    {
        roadList.Capacity = 10;
    }

    void Update()
    {
        for (int i = 0; i < roadList.Count; i++)
        {
            roadList[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public void NewPosition()
    {
        newRoad.Add(roadList[0]);
        roadList.RemoveAt(0);

        newRoad[0].transform.position = targetPosition;

        roadList.Add(newRoad[0]);
    }
}
