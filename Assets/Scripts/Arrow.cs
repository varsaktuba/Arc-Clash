using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            BossHealth.instance.TakeDamage(5);
        }
    }
}
