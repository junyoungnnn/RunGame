using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }


    void Update()
    {
        Move();
    }

    public void Move()
    {
        // 왼쪽 방향키를 누르면
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine == RoadLine.MIDDLE)
            {
                roadLine = RoadLine.LEFT;
            }
            else if (roadLine == RoadLine.RIGHT)
            {
                roadLine = RoadLine.MIDDLE;
            }
        }

        // 오른쪽 방향키를 누르면
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine == RoadLine.MIDDLE)
            {
                roadLine = RoadLine.RIGHT;
            }
            else if (roadLine == RoadLine.LEFT)
            {
                roadLine = RoadLine.MIDDLE;
            }
        }

        //// 왼쪽 방향키를 누르면
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    if (roadLine <= RoadLine.LEFT)
        //    {
        //        roadLine = RoadLine.LEFT;
        //    }
        //    else
        //    {
        //        roadLine--;
        //    }
        //}

        ////오른쪽 방향키를 누르면
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    if (roadLine >= RoadLine.RIGHT)
        //    {
        //        roadLine = RoadLine.RIGHT;
        //    }
        //    else
        //    {
        //        roadLine++;
        //    }
        //}
    }
}


