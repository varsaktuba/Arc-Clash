using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSurrounder : MonoBehaviour
{
    public GameObject surrounderObj;
    public int surObjCount;

    private readonly float appearWaitDuration = 0.1f;
    private Transform surParentTransform;

    // Start is called before the first frame update
    void Start()
    {
        surParentTransform = new GameObject(name: gameObject.name + "Surrounder Parent").transform;
        StartCoroutine(routine: SurroundStepAnimated());

    }

    IEnumerator SurroundStepAnimated()
    {
        float AngleStep = 360.0f / surObjCount;

        surrounderObj.transform.SetParent(surParentTransform);

        for(int i=1; i < surObjCount; i++)
        {
            GameObject newSurrounderObj = Instantiate(surrounderObj);

            newSurrounderObj.transform.RotateAround(point: transform.position, axis: Vector3.up, angle: AngleStep * i);
            newSurrounderObj.transform.SetParent(surParentTransform);

            yield return new WaitForSeconds(appearWaitDuration);
        }
    }

}
