using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurrounderObjController : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    Animator anim;
    public float currentHealth;
    public float maxHealth = 5f;


    public bool isDead;

   private Vector3 destination = new Vector3(0.13f, 0.5f, 46.99f);
    [SerializeField] private float speed = 1;
   

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (currentHealth < 1)
        {
            isDead = true;
            DestroyTheObject();
            
        }
        if (BossHealth.instance.isDead)
        {
            anim.SetBool("Running", true);
            playerManager.playerState = PlayerManager.PlayerState.Attack;

            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            transform.Rotate(0, 0, 0);
            if(transform.position == destination)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            TakeDamage(5);
        }
       
    }
    

    void DestroyTheObject()
    {
        playerManager.collidedList.RemoveAt(0);
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

    }
}
