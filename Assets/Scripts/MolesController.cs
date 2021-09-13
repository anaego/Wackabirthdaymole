using System.Collections;
using UnityEngine;

public class MolesController : MonoBehaviour
{
    public MoleHole[] moleHoles;
    public HoleMole moleInAHole;

    private HoleMole currentMole;
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
                currentMole = Instantiate(moleInAHole, moleHole.transform);
                yield return new WaitForSeconds(1);
                Destroy(currentMole.gameObject);
                moleHole.HasMoleNow = false;
                yield return null;
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
            if (currentMole != null)
            {
                Destroy(currentMole.gameObject);
            }
        }
    }

    public void StartMoleMovingCoroutine()
    {
        moleMovingCoroutine = StartCoroutine(MoveMolesBetweenHoles());
    }
}
