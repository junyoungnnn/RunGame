using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX = 3.5f;

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }


    void Update()
    {
        Move();
        Status();
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
        //    if (roadLine > RoadLine.LEFT)
        //    {
        //        roadLine--;
        //    }
        //}

        ////오른쪽 방향키를 누르면
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    if (roadLine < RoadLine.RIGHT)
        //    {
        //       roadLine++;
        //    }
        //}
    }

    public void Status()
    {
        switch(roadLine)
        {
            case RoadLine.LEFT:

                Movement(-positionX);
                break;

            case RoadLine.MIDDLE:

                Movement(0);
                break;

            case RoadLine.RIGHT:

                Movement(positionX);
                break;
        }
    }

    public void Movement(float positionX)
    {
        transform.position = new Vector3(positionX, 0, 0);
    }
}


