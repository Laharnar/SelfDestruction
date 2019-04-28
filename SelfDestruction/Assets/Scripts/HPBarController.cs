using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    public Image image;
    public HealthController hp;
    private float maxHP;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = hp.health;
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = hp.health / maxHP;
    }
}
