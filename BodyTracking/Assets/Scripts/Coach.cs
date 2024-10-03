using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coach : MonoBehaviour
{

    public Animator animator;
   
    void Start()
    {
        animator = GetComponent<Animator>();

    }


    void Update()
    {
        if (MovementCompare.instance.animatorbool == true)
        {
            animator.SetBool("Dumbles", true);
        }

        if (MovementCompare.instance.animatorbool == false)
        {
            animator.SetBool("Dumbles", false);
        }

        if (AirSquart.instance.anibool == false)
        {
            animator.SetBool("airsquart",false);
          
        }
        if (AirSquart.instance.anibool == true)
        {
           animator.SetBool("airsquart",true);
           
           
        }

    }
}
