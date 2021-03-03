using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public static BossHealth instance;
    public float currentHealth;
    public float maxHealth = 200f;

    public Slider healthBar;
    private Animator anim;
    public bool isDead;
    public GameObject board;
    public PlayerManager playerManager;
    public GameManager gm;

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
        currentHealth = maxHealth;
        healthBar.value = maxHealth;
        healthBar.maxValue = maxHealth;

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float hit = anim.GetFloat("hit");
        
        if(hit > 0)
        {
            hit -= Time.deltaTime * 3;
            anim.SetFloat("hit", hit);
        }
        if(currentHealth < 1)
        {
            isDead = true;
            anim.SetBool("isDead", true);
            Destroy(gameObject, 1f);
            board.SetActive(true);
        }
        else if(currentHealth >1 && playerManager.collidedList.Count <= 0)
        {
            StartCoroutine(EndGame());
        }
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
        gm.EndGame();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        anim.SetFloat("hit", 1);
    }
}
