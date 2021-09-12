using System.Collections;
using UnityEngine;

public class MolesController : MonoBehaviour
{
    public MoleHole[] moleHoles;
    public HoleMole moleInAHole;

    private Coroutine moleMovingCoroutine;

    private void Start()
    {
        ShuffleMoleHoles();
        StartMoleMovingCoroutine();
    }

    public void ShuffleMoleHoles()
    {
        for (int i = 0; i < moleHoles.Length - 1; i++)
        {
            int randomRange = Random.Range(i, moleHoles.Length);
            var temp = moleHoles[randomRange];
            moleHoles[randomRange] = moleHoles[i];
            moleHoles[i] = temp;
        }
    }

    public IEnumerator MoveMolesBetweenHoles()
    {
        while (true)
        {
            foreach (var moleHole in moleHoles)
            {
                moleHole.HasMoleNow = true;
                var mole = Instantiate(moleInAHole, moleHole.transform);
                yield return new WaitForSeconds(1);
                Destroy(mole);
                moleHole.HasMoleNow = false;
            }
            yield return null;
        }
    }

    public void StopMoleMovingCoroutine()
    {
        if (moleMovingCoroutine != null)
        {
            StopCoroutine(moleMovingCoroutine);
            moleMovingCoroutine = null;
        }
    }

    public void StartMoleMovingCoroutine()
    {
        moleMovingCoroutine = StartCoroutine(MoveMolesBetweenHoles());
    }
}
