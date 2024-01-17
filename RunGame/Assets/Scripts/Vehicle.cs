using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed = 5.0f;
    [SerializeField] List<Vehicle> vehicles;

    private void OnEnable()
    {
        direction = Vector3.forward;
    }

    public void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public override void Activate(Runner runner)
    {
        Debug.Log("Game over");
    }



}
