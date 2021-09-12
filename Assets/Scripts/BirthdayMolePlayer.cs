using UnityEngine;

public class BirthdayMolePlayer : MonoBehaviour
{
    public Cake cake;

    public void ThrowCake(MoleHole moleHole)
    {
        cake.MoveCakeToHole(moleHole.transform.position);
    }
}
