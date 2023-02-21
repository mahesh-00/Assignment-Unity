using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveRange = 10f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        initialPosition = transform.position;
        GetNewTargetPosition();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            GetNewTargetPosition();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void GetNewTargetPosition()
    {
        float randomX = Random.Range(initialPosition.x - moveRange, initialPosition.x + moveRange);
        float randomZ = Random.Range(initialPosition.z - moveRange, initialPosition.z + moveRange);
        targetPosition = new Vector3(randomX, initialPosition.y, randomZ);
    }
}
