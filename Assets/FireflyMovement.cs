using System.Collections;
using UnityEngine;

public class FireflyMovement : MonoBehaviour
{
    private float movementSpeed;
    private Vector2 movementRange;

    public void StartMovement(float speed, Vector2 range)
    {
        movementSpeed = speed;
        movementRange = range;
        StartCoroutine(MoveFirefly());
    }

    private IEnumerator MoveFirefly()
    {
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = GetRandomTargetPosition();

        while (true)
        {
            while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
            targetPosition = GetRandomTargetPosition();
        }
    }

    private Vector2 GetRandomTargetPosition()
    {
        return (Vector2)transform.position + new Vector2(
            Random.Range(-movementRange.x, movementRange.x),
            Random.Range(-movementRange.y, movementRange.y)
        );
    }
}