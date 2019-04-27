using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public Animator bossAnimator;


    // Start is called before the first frame update
    void GoLeft()
    {
        bossAnimator.SetTrigger("GoLeft");
    }

    void GoRight()
    {
        bossAnimator.SetTrigger("GoRight");
    }


}
