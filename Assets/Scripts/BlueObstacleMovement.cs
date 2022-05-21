using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueObstacleMovement : MonoBehaviour
{
    [SerializeField] float yAxisMovement = 0.01f;
    [SerializeField] int upperBounds = 10;
    [SerializeField] int lowerBounds = 1;

    int movementDirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= upperBounds) {
            movementDirection = -1;
        } else if (transform.position.y <= lowerBounds) {
            movementDirection = 1;
        }
        Debug.Log(movementDirection);
        ObstacleMotion(movementDirection);
    }
    
    void ObstacleMotion(int direction) {
        float yAxisMovementSpeed = yAxisMovement * Time.deltaTime * direction;
        transform.Translate(0, yAxisMovementSpeed, 0);
    }
}
