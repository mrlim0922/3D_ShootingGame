using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public GameObject[] BossFirePoint;
    public GameObject[] Child;
    public GameObject BossBolt;
    public WaitForSeconds BossAttackDelay;

    private void Update()
    {
        StartCoroutine(BossAttack());
    }

    IEnumerator BossAttack()
    {
        yield return BossAttackDelay;
    }
}
