using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public GameObject[] shapes;
    public GameObject[] nextShapes;
    private GameObject upNextObject = null;

    private int shapeIndex = 0;
    private int nextShapeIndex = 0;
    public void SpawnShape()
    {
        int shapeIndex = nextShapeIndex;
        Instantiate(shapes[shapeIndex], transform.position, Quaternion.identity);

        nextShapeIndex = Random.Range(0, 6);
        Vector3 nextShapePos = new Vector3(0,0,0);

        if(upNextObject != null)
            Destroy(upNextObject);
        upNextObject = Instantiate(nextShapes[nextShapeIndex], nextShapePos, Quaternion.identity);
    }
    // Use this for initialization
    void Start()
    {
        nextShapeIndex = Random.Range(0, 6);
        SpawnShape();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
