using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] PlayerManager playerManager;

    
    private Rigidbody rb;
    private bool isGrounded;
    public bool isDetectedEnemy;
    Animator anim;

    public GameObject surrObj;

   

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody>();

        playerManager.collidedList.Add(gameObject);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
     
        if (BossHealth.instance.isDead)
        {
            gameObject.SetActive(false);
            
          
        }
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")){
           Grounded();
            anim.SetBool("Running", true);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            isDetectedEnemy = true;
            playerManager.playerState = PlayerManager.PlayerState.Stop;
            FindObjectOfType<DetectScript>().detected = true;
            surrObj.SetActive(true);
            StartCoroutine(Hide());
          
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    void Grounded()
    {
        isGrounded = true;
        playerManager.playerState = PlayerManager.PlayerState.Move;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    //void Attack()
    //{
    //    isDetectedEnemy = true;
    //    playerManager.playerState = PlayerManager.PlayerState.Stop;
    //    anim.SetBool("Shooting", true);
    //}


}
