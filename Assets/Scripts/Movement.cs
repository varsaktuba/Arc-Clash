using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Movement : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float movementSpeed;
    [SerializeField] float controlSpeed;

    //Touch settings
    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;

    //Surround
    public GameObject surrounderObj;
    public int surObjCount;

    private readonly float appearWaitDuration = 0.1f;
    private Transform surParentTransform;
    public Transform Boss;
    public Transform SurParent;
    private bool llamcalled  = false;

    // Start is called before the first frame update
    void Start()
    {
        surrounderObj.SetActive(false);
        surrounderObj.transform.SetParent(surParentTransform);
        surParentTransform = SurParent.transform;
        //surParentTransform = new GameObject(name: gameObject.name + "Surrounder Parent").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        surObjCount = playerManager.collidedList.Count;
    }
    private void FixedUpdate()
    {
        if(playerManager.playerState == PlayerManager.PlayerState.Move)
        {
            transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;

        }
        if(playerManager.playerState == PlayerManager.PlayerState.Stop)
        {
            if (!llamcalled)
            {
                StartCoroutine(routine: SurroundStepAnimated());
                llamcalled = true;
            }

        }
        if(playerManager.playerState == PlayerManager.PlayerState.Attack)
        {
           //transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
           //transform.Rotate(0, 0, 0);
        }
        if (isTouching)
        {
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
        }
        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
    }

  
    IEnumerator SurroundStepAnimated()
    {
        float AngleStep = 360.0f / surObjCount;

        //surrounderObj.transform.SetParent(surParentTransform);

        for (int i = 1; i < surObjCount; i++)
        {
            GameObject newSurrounderObj = Instantiate(surrounderObj);
            newSurrounderObj.SetActive(true);
            newSurrounderObj.transform.RotateAround(point: Boss.transform.position, axis: Vector3.up, angle: AngleStep * i);
            newSurrounderObj.transform.SetParent(surParentTransform);

            yield return new WaitForSeconds(appearWaitDuration);
        }
    }
    void GetInput()
    {
        if (Input.GetMouseButton(1))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
}
