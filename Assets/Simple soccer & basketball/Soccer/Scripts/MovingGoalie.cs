
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGoalie : MonoBehaviour
{
    public float moveDistance = 5f; // Adjust the distance the goalie moves
    public float moveSpeed = 2f; // Adjust the speed of movement
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 nextPos;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.right * moveDistance;
        nextPos = endPos;
    }

    private void Update()
    {
        MoveGoalie();
    }

    private void MoveGoalie()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, nextPos) < 0.01f)
        {
            ToggleNextPosition();
        }
    }

    private void ToggleNextPosition()
    {
        nextPos = nextPos == startPos ? endPos : startPos;
    }
}
