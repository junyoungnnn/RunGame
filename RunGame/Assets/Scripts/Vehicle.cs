using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    public float GetSpeed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void OnEnable()
    {
        direction = Vector3.forward;

        GameManager.instance.ControlRandomSpeed();

        speed = GameManager.instance.speed + Random.Range(GameManager.instance.minRandomSpeed, GameManager.instance.maxRandomSpeed);
    }

    public void Update()
    {
        if (GameManager.instance.state == false)
        {
            return;
        }

        transform.Translate(direction * speed * Time.deltaTime);
        
    }

}
