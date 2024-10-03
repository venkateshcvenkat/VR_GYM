using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AirSquart : MonoBehaviour
{
    [Header("-----AirSquart-----")]

    public Transform airsquartStartPoint;
    public Transform airsquartEndPoint;
    public float airsquartDistance;
    public bool d_checkbool, anibool, isverify, scorebool;
    public int squartcount = 0, countdowntime;
    public TextMeshProUGUI countText, timerText;
    public TextMeshProUGUI note, firstset, nextworkout, secondset, thirdset;
    public static AirSquart instance;
    public health healthscript;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        note.enabled = true;
        firstset.enabled = false;
        nextworkout.enabled = false;
        secondset.enabled = false;
        thirdset.enabled = false;
        timerText.enabled = false;
        anibool = true;

    }
    void Update()
    {
        AirSquartDistance();
        condition();
    }
    public void AirSquartDistance()
    {
        airsquartDistance = Vector3.Distance(airsquartStartPoint.position, airsquartEndPoint.position) * 100;
        if (!scorebool)
        {

            if (airsquartDistance > 95 && airsquartDistance < 96 && !d_checkbool)
            {
                d_checkbool = true;
            }
            if (airsquartDistance <= 50 && d_checkbool)
            {
                d_checkbool = false;
                squartcount++;
                countText.text = squartcount.ToString() + "/15";
                healthscript.TakeDamge(1);
            }
        }     
    }
    public void condition()
    {
        if (squartcount == 5 && !isverify)
        {

            note.enabled = false;
            firstset.enabled = true;
            anibool = false;
            isverify = true;
            scorebool = true;
            StartCoroutine(countdown());
            StartCoroutine(firstsetAfter());

        }
        if (squartcount == 10 && isverify)
        {
            isverify = false;
            secondset.enabled = true;
            anibool = false;
            scorebool = true;
            StartCoroutine(countdown());
            StartCoroutine(secondsetAfter());
        }
        if (squartcount == 15)
        {
            thirdset.enabled = true;
            anibool = false;
            scorebool = true;
        }
    }
    IEnumerator countdown()
    {
        while (countdowntime > 0)
        {
            timerText.enabled = true;
            timerText.text = countdowntime.ToString();
            yield return new WaitForSeconds(1f);
            countdowntime--;
        }


        timerText.enabled = false;
        countdowntime = 10;
    }
    IEnumerator firstsetAfter()
    {
        yield return new WaitForSeconds(10);
        anibool = true;
        firstset.enabled = false;
        nextworkout.enabled = true;
        scorebool = false;
        yield return new WaitForSeconds(12);
        nextworkout.enabled = false;
    }
    IEnumerator secondsetAfter()
    {
        yield return new WaitForSeconds(10);
        anibool = true;
        secondset.enabled = false;
        nextworkout.enabled = true;
        scorebool = false;
        yield return new WaitForSeconds(12);
        nextworkout.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(airsquartStartPoint.position, 0.1f);
        Gizmos.DrawWireSphere(airsquartEndPoint.position, 0.1f);
    }

}
