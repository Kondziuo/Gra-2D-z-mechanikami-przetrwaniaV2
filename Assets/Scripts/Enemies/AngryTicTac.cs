using UnityEngine;

public class AngryTicTac : MonoBehaviour
{
    public Transform player; 
    public float speed = 10f;
    public float attackCooldown = 1f;

    float attackTimer = 0f;
    bool isAttacking = false;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

    }

    void Update()
    {
        if (player != null)
        {
            if (!isAttacking)
            {
                transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
                );

            }
            else
            {
                if (Time.time >= attackTimer)
                {
                    Attack();
                }


            }
            transform.rotation = Quaternion.identity;
           
        }
    }
    
        void Attack()
    {
        attackTimer = Time.time + attackCooldown;
        PlayerHealth hp = player.GetComponent<PlayerHealth>();
        if (hp != null)
        {
            hp.TakeDamage(20f);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacking = false;
        }
    }

}
