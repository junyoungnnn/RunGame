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
    public Animator animator;
    

    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX = 2.25f;
    [SerializeField] float lerpSpeed = 5.0f;
    [SerializeField] LeftCollider leftCollider;
    [SerializeField] RightCollider rightCollider;

    private void OnEnable()
    {
        // InputManager.instance.keyAction += Move;
    }

    void Start()
    {
        InputManager.instance.keyAction += Move;
        roadLine = RoadLine.MIDDLE;
    }


    void Update()
    {
        Status();
    }

    public void Move()
    {
        if (GameManager.instance.state == false)
        {
            return;
        }

        // 왼쪽 방향키를 누르면
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(leftCollider.Detector)
            {
                return;
            }
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
            if(rightCollider.Detector)
            {
                return;
            }
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
        transform.position = Vector3.Lerp(transform.position, new Vector3(positionX, 0, 0), Time.deltaTime * lerpSpeed);
    }

    private void OnDisable()
    {
        InputManager.instance.keyAction -= Move;
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionObject collisionObject = other.GetComponent<CollisionObject>();

        if(collisionObject != null) 
        {
            collisionObject.Activate(this);
        }
    }
}


