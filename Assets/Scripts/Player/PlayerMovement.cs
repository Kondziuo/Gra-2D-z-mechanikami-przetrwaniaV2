using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 move;
    Vector2 facing = Vector2.down;
    [SerializeField] float attackRange = 0.7f;
    [SerializeField] float speed = 5f;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject invetoryPanel;
    [SerializeField] LayerMask interactableLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        move = Vector2.zero;
        
        if (Keyboard.current.wKey.isPressed) move.y += 1;
        if (Keyboard.current.sKey.isPressed) move.y -= 1;
        if (Keyboard.current.aKey.isPressed) move.x -= 1;
        if (Keyboard.current.dKey.isPressed) move.x += 1;

        if (move != Vector2.zero)
        {
            facing = move;
            animator.SetFloat("Horizontal", facing.x);
            animator.SetFloat("Vertical", facing.y);

        }

        move = move.normalized;
        animator.SetFloat("Speed", move.magnitude);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Attack();
        }

        if (invetoryPanel.activeSelf)
        {
            move = Vector2.zero;
            animator.SetFloat("Speed", 0);
            return;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }

    void Attack()
    {
        

        RaycastHit2D hit = Physics2D.Raycast(
            rb.position,
            facing,
            attackRange,
            interactableLayer
        );


        if (hit.collider != null)
        {
        
            Tree tree = hit.collider.GetComponent<Tree>();
            if (tree != null)
            {
            tree.Hit(inventory);
            }
        
            Stone stone = hit.collider.GetComponent<Stone>();
            if (stone != null) { 
            stone.Hit(inventory);
            }

            Meat meat = hit.collider.GetComponent<Meat>();
            if (meat != null)
            {
                meat.Hit(inventory);
            }

        }



    }
}
