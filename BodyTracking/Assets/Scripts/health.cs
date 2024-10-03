using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int Maxhealth = 15;

    public int currenthealth;

    public healthbar healthbar;
    

   
    private void Start()
    {

        Maxhealth = currenthealth;
        healthbar.Setmaxhealth(currenthealth);
    }
    private void Update()
    {
       
    }

    public void TakeDamge(int damage)
    {
        currenthealth += damage;

        healthbar.sethealth(currenthealth);
    }
}
