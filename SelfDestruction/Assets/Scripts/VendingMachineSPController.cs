using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachineSPController : MonoBehaviour
{
    private Text sPCounter;
    private Player player;
    float collectTime;
    float collectRate = 0.2f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D (Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            player.ChangeSprite();
            if (Time.time > collectTime && player.sPCount < player.sPMax)
            {
                collectTime = Time.time + collectRate;
                player.sPCount++;
                collision.gameObject.GetComponent<HealthController>().Damage(5);
            }
        }
    }
}
