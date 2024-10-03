using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activity : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float difference,ans;
    void Start()
    {
        
    }

    
    void Update()
    {
        /* if (player1.transform.rotation.y >= 15)
         {
             Debug.Log("1==below15");
         }
         if (player1.transform.rotation.y >= 50)
         {
             Debug.Log("1==Above50");
         }*/

        if ((player2.transform.rotation.y >= 20f) && (player2.transform.rotation.y >= -20f))
        {
            Debug.Log("negative values");
        }
        if ((player2.transform.rotation.y <=20f)  &&  (player2.transform.rotation.y <=50f) )
        {
            Debug.Log("2==Above20");
        }
        if (player2.transform.rotation.y <= 60f)
        {
            Debug.Log("above 60");
          //  Debug.Log(Mathf.Clamp(player2.transform.rotation.y, -20f, 50f));
        }

        difference = player1.transform.rotation.y - player2.transform.rotation.y;

        // Ans = Mathf.Clamp(diffence, -0.001f, 0.004f);

        /* if( diffence > -0.0050)
         {
             Debug.Log("high");

         }
         if( diffence < -0.0009)
         {
             Debug.Log("low");
         }
         if((diffence >= -0.001) && ( diffence <= -0.0049))
         {
             Debug.Log("avg");
         }*/
       
        if (difference < -0.0009f)
        {
            Debug.Log("low");
        }
        if (difference > -0.0050f)
        {
            Debug.Log("high");
        }
        if (difference >= -0.001f && difference <= -0.0049f)
        {
            Debug.Log("avg");
        }


    }
}       
