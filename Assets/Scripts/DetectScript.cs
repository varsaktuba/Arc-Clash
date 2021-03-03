using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScript : MonoBehaviour
{
    public bool detected;
    [SerializeField]GameObject target;
    public Transform enemy;

    public GameObject bullet;
    public Transform shootPoint;

    public float shootSpeed;
    public float timeToShoot = 1.3f;
    float originalTime;
    public GameObject surParent;

    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeToShoot;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (detected)
        {
            target = surParent.transform.GetChild(0).gameObject;
            enemy.LookAt(target.transform);
            //    enemy.LookAt(target.transform);
        }
        if (BossHealth.instance.isDead)
        {
            DontShoot();
        }
    }
    private void FixedUpdate()
    {
        if (detected)
        {
            timeToShoot -= Time.deltaTime;
            if (timeToShoot < 0)
            {
                ShootPlayer();
                timeToShoot = originalTime;
            }
        }
    }

    void ShootPlayer()
    {
        Vector3 position = new Vector3(Random.Range(-0.5f,0.5f), 1.41f, 54.56f);
        GameObject currentBullet = Instantiate(bullet, position, shootPoint.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        shootSpeed = Random.Range(5f, 10f);
        rb.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
        Destroy(currentBullet, 1f);
    }
    void DontShoot()
    {
        Destroy(this);
    }
}
