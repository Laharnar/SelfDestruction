using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBarController : MonoBehaviour
{
    public Image image;
    public HealthController bosshp;
    private float bossmaxHP;

    // Start is called before the first frame update
    void Start()
    {
        bossmaxHP = bosshp.health;
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = bosshp.health / bossmaxHP;
    }
}
