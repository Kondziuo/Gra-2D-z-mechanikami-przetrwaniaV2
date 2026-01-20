using UnityEngine;

public class Trap : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player")) 
        { 
        
        Debug.Log("ALAAAAAAAAAAAA");
        
        PlayerHealth hp = collision.GetComponent<PlayerHealth>();

            if (hp != null)
            {
                hp.TakeDamage(20f);
            }

            }
    }




}
