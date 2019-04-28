using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMachineController : MonoBehaviour
{

    private Player player;
    private HealthController playerHealth;
    private int healingPerSecond=5;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerHealth = player.GetComponent<HealthController>();
    }

    private void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.health += Time.deltaTime*healingPerSecond;
        }
    }
}
