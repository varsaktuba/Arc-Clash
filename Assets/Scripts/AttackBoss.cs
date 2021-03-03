using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss : MonoBehaviour
{
   
    public  GameObject target;
    public Transform surrounder;

    public GameObject bullet;
    public Transform shootPoint;

    private float shootSpeed = 10f;
    private float timeToShoot = 2f;
    float originalTime;

   

    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
    
            surrounder.LookAt(target.transform);
       
        if (BossHealth.instance.isDead)
        {
            DontShoot();
        }
    }
    private void FixedUpdate()
    {
      
            timeToShoot -= Time.deltaTime;
            if (timeToShoot < 0)
            {
                ShootBoss();
                timeToShoot = originalTime;
            }
      
    }

    void ShootBoss()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
        Destroy(currentBullet, 1f);
    }
    void DontShoot()
    {
        Destroy(this);
    }
}
