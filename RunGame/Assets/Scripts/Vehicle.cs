using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : CollisionObject
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
        speed = GameManager.instance.speed + Random.Range(5, 20);
        direction = Vector3.forward;
    }

    public void Update()
    {
        if (GameManager.instance.state == false)
        {
            return;
        }

        transform.Translate(direction * speed * Time.deltaTime);
        
    }

    public override void Activate(Runner runner)
    {
        runner.animator.Play("Die");
        GameManager.instance.GameOver();
    }

}
