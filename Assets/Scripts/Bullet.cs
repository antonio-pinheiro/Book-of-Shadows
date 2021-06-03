using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    private float timeDestroy;
    public int hit;

    // Start is called before the first frame update
    void Awake()
    {
        timeDestroy = 180.0f;
        Destroy(gameObject, timeDestroy);
        hit = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.EnemyHit(hit);
                Destroy (gameObject);
            }
        }
        
    }
}
