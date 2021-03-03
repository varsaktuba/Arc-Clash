using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoPlayerController : MonoBehaviour
{

    public PlayerManager playerManager;


    void Update()
    {
        if (BossHealth.instance.isDead)
        {
            gameObject.SetActive(false);
        }

    }
  


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            DestroyTheObject();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
           
            Destroy(gameObject, 0.5f);
        }
       
    }
    void DestroyTheObject()
    {
        playerManager.collidedList.Remove(gameObject);
        Destroy(gameObject);
    }

   



}
