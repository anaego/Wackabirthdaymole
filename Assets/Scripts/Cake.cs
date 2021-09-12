using System;
using System.Collections;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;

    private float cakeSpeed = 500f;
    private Vector2 homePosition;
    private bool isThrowing = false;

    private void Start()
    {
        homePosition = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Here");
        if (collision.GetComponent<MoleHole>().HasMoleNow)
        {
            scoreController.ChangeScore(1);
        }
        else
        {
            scoreController.ChangeScore(-1);
        }
        StartCoroutine(ReturnCake());
    }

    private IEnumerator ReturnCake()
    {
        yield return new WaitForSeconds(0.3f);
        transform.position = homePosition;
    }

    internal void MoveCakeToHole(Vector3 position)
    {
        if (isThrowing) return;
        StartCoroutine(MoveCakeToHoleCoroutine(position));
    }

    private IEnumerator MoveCakeToHoleCoroutine(Vector3 destination)
    {
        isThrowing = true;
        animator.SetTrigger("StartFlying");
        while (Mathf.Abs(this.transform.position.x - destination.x) > 0.0001 && Mathf.Abs(this.transform.position.y - destination.y) > 0.0001)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, destination, cakeSpeed * Time.deltaTime);
            yield return null;
        }
        isThrowing = false;
        yield return null;
    }
}
