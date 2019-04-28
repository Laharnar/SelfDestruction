using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachineSPController : MonoBehaviour
{
    [SerializeField] private Text sPCounter;
    private int sPCount=0;
   
    private void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("you bought a superpower");
                collision.gameObject.GetComponent<Player>().sPCount++;
                sPCount = collision.gameObject.GetComponent<Player>().sPCount;
                sPCounter.text=""+sPCount;
                collision.gameObject.GetComponent<HealthController>().Damage(5);
            }
        }
    }
}
