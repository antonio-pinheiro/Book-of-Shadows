using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        health = 2;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (isMoving)
        {
            float step =  Mathf.Abs(speed) * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);

        }

    }
}
