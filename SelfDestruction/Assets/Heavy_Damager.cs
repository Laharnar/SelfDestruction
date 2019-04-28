using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy_Damager : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(Damager());
    }

    IEnumerator Damager()
    {
            yield return new WaitForSeconds(1f);
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 2f, Vector2.up);
        for (int i = 0; i<hit.Length; i++)
        if (hit[i].transform != null && hit[i].transform.tag == "Player")
        {
            hit[i].transform.GetComponent<HealthController>().Damage(99999);
        }
           

    }
}
