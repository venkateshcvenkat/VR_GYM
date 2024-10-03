using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlManager : MonoBehaviour
{
    public MovementCompare DhambulesScript;
    public AirSquart AirSquartScript;
    public GameObject DhambulesCanvas;
    public GameObject squartCanvas;
    public GameObject D_health, A_health;
    void Start()
    {
        DhambulesScript.enabled = true;
        DhambulesCanvas.SetActive(true);
        D_health.SetActive(true);

        AirSquartScript.enabled = false;
        squartCanvas.SetActive(false);
        A_health.SetActive(false) ;
    }

    
    void Update()
    {
        if (MovementCompare.instance.airsquartON == true)
        {
            DhambulesScript.enabled = false;
            DhambulesCanvas.SetActive(false);
            D_health.SetActive(false);

            AirSquartScript.enabled = true;
            squartCanvas.SetActive(true);
            A_health.SetActive(true);
        }
    }
}
