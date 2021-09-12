using UnityEngine;

public class Cake : MonoBehaviour
{
    public ScoreController scoreController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MoleHole>().HasMoleNow)
        {
            scoreController.ChangeScore(1);
        }
        else
        {
            scoreController.ChangeScore(-1);
        }
    }
}
