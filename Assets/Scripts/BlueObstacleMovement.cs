using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueObstacleMovement : MonoBehaviour
{
    [SerializeField] float yAxisMovement = 0.01f;
    [SerializeField] int upperBounds = 10;
    [SerializeField] int lowerBounds = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMovementDirection();
        ObstacleMotion();
    }

    int ChangeMovementDirection() {
        int movementDirection = 1;
        if ((transform.position.y > upperBounds) || (transform.position.y < lowerBounds)) {
            movementDirection *= -1;
        }
        return movementDirection;
    }
    void ObstacleMotion() {
        int moveUpOrDown = ChangeMovementDirection();
        float yAxisMovementSpeed = yAxisMovement * Time.deltaTime;
        float actualObstacleMotion = yAxisMovementSpeed * moveUpOrDown;
        transform.Translate(0, actualObstacleMotion, 0);
    }
}
