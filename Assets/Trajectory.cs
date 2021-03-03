using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trajectory : MonoBehaviour
{
    private Scene scenePrediction;
    private PhysicsScene scenePredictionPhysics;
    public Rigidbody prediction;
    public int predictionCycles = 100;
    public GameObject pointTemplete;
    public List<GameObject> point;

    private void Start()
    {
        CreateSceneParameters sceneParam = new CreateSceneParameters(LocalPhysicsMode.Physics3D);
        scenePrediction = SceneManager.CreateScene("PredictionPhysics", sceneParam);
        scenePredictionPhysics = scenePrediction.GetPhysicsScene();
    }

    void CreatePoints()
    {
        point = new List<GameObject>();
        for (int i = 0; i < predictionCycles; i++)
        {
            point.Add(Instantiate(pointTemplete, transform));
        }
    }

    public void Create(Vector3 pos, Vector3 force)
    {
        if (!scenePredictionPhysics.IsValid())
            return;

        Clear();

        Rigidbody predictionBall = Instantiate(prediction, pos, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(predictionBall.gameObject, scenePrediction);
        predictionBall.AddForce(force);

        for (int i = 0; i < predictionCycles; i++)
        {
            scenePredictionPhysics.Simulate(Time.fixedDeltaTime);

            AddPoint(i, predictionBall.transform.position);
        }

        Destroy(predictionBall.gameObject);
    }

    void AddPoint(int index, Vector3 pos)
    {
        point[index].SetActive(true);
        point[index].transform.position = pos;
    }

    public void Clear()
    {
        point.ForEach((gobj) => {
            if (gobj.activeInHierarchy) gobj.SetActive(false);
        });
    }

    //public Vector3 direction;
    //public float force;
    //public GameObject dotsPrefab;
    //public GameObject[] dots;

    //public int numberOfDots;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    dots = new GameObject[numberOfDots];

    //    for (int i = 0; i < numberOfDots; i++)
    //    {
    //        dots[i] = Instantiate(dotsPrefab, transform.position, Quaternion.identity);
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    Vector3 bowpos = transform.position;

    //    direction = bowpos - mousePos;

    //    FaceMouse();

    //    for (int i = 0; i < numberOfDots; i++)
    //    {
    //        dots[i].transform.position = DotPosition(i * 0.1f);
    //    }
    //}

    //void FaceMouse()
    //{
    //    transform.forward = direction;
    //}

    //Vector3 DotPosition(float t)
    //{
    //    Vector3 currentPointPos = (Vector3)transform.position + (direction.normalized * force * t) + 0.5f * Physics.gravity * (t * t);
    //    return currentPointPos;
    //}
}
