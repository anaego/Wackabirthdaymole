using System;
using System.Collections;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public AudioClip hit;
    public AudioClip miss;
    public AudioSource audioSource;

    private float cakeSpeed = 35f;
    private Vector2 homePosition;
    private bool isThrowing = false;
    private bool landed = false;
    private Coroutine coroutine;

    private void Start()
    {
        homePosition = this.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (landed)
        {
            landed = false;
            if (collision.GetComponent<MoleHole>().HasMoleNow)
            {
                audioSource.PlayOneShot(hit);
                scoreController.ChangeScore(1);
            }
            else
            {
                audioSource.PlayOneShot(miss);
                scoreController.ChangeMisses(1);
            }
            StartCoroutine(ReturnCake());
        }
    }

    private IEnumerator ReturnCake()
    {
        yield return new WaitForSeconds(0.05f);
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
        animator.SetBool("Idle", false);
        animator.SetBool("Flying", true);
        while (Mathf.Abs(this.transform.position.x - destination.x) > 0.0001 && Mathf.Abs(this.transform.position.y - destination.y) > 0.0001)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, destination, cakeSpeed * Time.deltaTime);
            yield return null;
        }
        isThrowing = false;
        landed = true;
        animator.SetBool("Flying", false);
        animator.SetBool("Idle", true);
        yield return null;
    }
}
