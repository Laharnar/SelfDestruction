using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachineSPController : MonoBehaviour
{
    [SerializeField] private Text sPCounter;
    private int sPCount=0;
    private Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("you bought a superpower");
                player.sPCount++;
                sPCount = player.sPCount;
                sPCounter.text=""+sPCount;
                collision.gameObject.GetComponent<HealthController>().Damage(5);
                player.ChangeSprite();
            }
        }
    }
}
