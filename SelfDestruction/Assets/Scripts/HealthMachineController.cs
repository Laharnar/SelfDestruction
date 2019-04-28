using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMachineController : MonoBehaviour
{

    private Player player;
    private HealthController playerHealth;
    public int healingPerSecond=25;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerHealth = player.GetComponent<HealthController>();
    }

    private void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerHealth.health<playerHealth.maxHealth)
        {
            playerHealth.health += Time.deltaTime*healingPerSecond;
        }
    }
}
