using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roadList;

    [SerializeField] float speed = 5.0f;
    [SerializeField] float offset = 24.3f;

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
        GameObject newRoad = roadList[0];

        roadList.Remove(newRoad);

        float newz = roadList[roadList.Count - 1].transform.position.z + offset;
        
        newRoad.transform.position = new Vector3(0,0, newz);

        roadList.Add(newRoad);
    }
}
