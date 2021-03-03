using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public GameManager gm;
    public PlayerManager playerManager;

    public ParticleSystem particle;
    Animator anim;
    
    public float currentHealth;
    public float maxHealth = 15f;

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float hit = anim.GetFloat("TowerHit");
        if (hit > 0)
        {
            hit -= Time.deltaTime * 3;
            anim.SetFloat("TowerHit", hit);
        }
        if (currentHealth < 1 && playerManager.collidedList.Count <=0)
        {
            
            Destroy(gameObject, 1f);
            StartCoroutine(WinScreen());
        }
        else if(currentHealth > 1 && playerManager.collidedList.Count <= 0)
        {
            StartCoroutine(EndGame());
        }
     
    }

    IEnumerator WinScreen()
    {
        yield return new WaitForSeconds(0.5f);
        gm.WinGame();
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        gm.EndGame();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TakeDamage(5);
            anim.SetFloat("TowerHit", 1);
            Destroy(other.gameObject, 1f);
            particle.Play();
            gm.ScoreText(100);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
      
    }
}
