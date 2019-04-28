using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPBarController : MonoBehaviour
{
    public Image image;
    public Text text;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.sPCount>0)
        image.fillAmount = 1;
        else
        image.fillAmount = 0;

        text.text = "" + player.sPCount;
    }
}
