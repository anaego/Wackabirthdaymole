using System.Collections;
using UnityEngine;

public class BirthdayMolePlayer : MonoBehaviour
{
    public Cake cake;
    public float cakeSpeed = 5f;

    private bool isThrowing = false;

    public void ThrowCake(MoleHole moleHole)
    {
        if (isThrowing) return;
        StartCoroutine(MoveToDestinationCoroutine(moleHole.transform.position));
    }

    private IEnumerator MoveToDestinationCoroutine(Vector3 destination)
    {
        isThrowing = true;
        while (transform.position != destination)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, cakeSpeed);
            yield return null;
        }
        isThrowing = false;
    }
}
