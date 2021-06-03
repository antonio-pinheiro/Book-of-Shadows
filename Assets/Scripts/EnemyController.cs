using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int health;
    public float speed;
    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected bool isMoving = false;
    protected Transform  player;
    protected SpriteRenderer sprite;
    public float distanceAttack;
    // Start is called before the first frame update
    


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    

    protected float DistanceAttack()
    {
        return Vector2.Distance(player.position, transform.position);
    }

    protected void Flip()
    {
        sprite.flipX = !sprite.flipX;
        speed *= -1;
    }

    protected virtual void Update()
    {
        float distance = DistanceAttack ();
        isMoving = (distance <= distanceAttack);

        if(isMoving){
            if((player.position.x > transform.position.x && sprite.flipX) || 
            (player.position.x < transform.position.x && !sprite.flipX)){
            Flip();
        }
        }
    }

    public void EnemyHit(int hitBullet)
    {
        health -= hitBullet;
        StartCoroutine(Hit());
        if (health < 1)
        {
            Destroy(gameObject);
        } 
    }

    IEnumerator Hit()
    {
      sprite.color = Color.red;
      yield return new WaitForSeconds(0.1f);
      sprite.color = Color.white;  
    }
}
