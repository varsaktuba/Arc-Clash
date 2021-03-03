using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObjController : MonoBehaviour
{
    PlayerManager playerManager;

   

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();

        
        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;

          
        }

      
    }
    private void Update()
    {
       
    }
   

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("CollectibleObj"))
        {
            if (!playerManager.collidedList.Contains(other.gameObject))
            {
                other.gameObject.tag = "CollectedObj";
                other.transform.parent = playerManager.collectedPoolTransform;
                playerManager.collidedList.Add(other.gameObject);
                other.gameObject.AddComponent<CollectibleObjController>();
                other.gameObject.GetComponent<Animator>().SetBool("CoRunning", true);
            }
        }
      
     
       
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("CollectibleList"))
        {
            other.transform.GetComponent<BoxCollider>().enabled = false;
            other.transform.parent = playerManager.collectedPoolTransform;

            foreach (Transform child in other.transform)
            {
                if (!playerManager.collidedList.Contains(child.gameObject))
                {
                    playerManager.collidedList.Add(child.gameObject);
                    child.gameObject.tag="CollectedObj";
                    child.gameObject.AddComponent<CollectibleObjController>();
                    child.gameObject.GetComponent<Animator>().SetBool("CoRunning", true);

                }
            }
        }
    }
  
   
}
