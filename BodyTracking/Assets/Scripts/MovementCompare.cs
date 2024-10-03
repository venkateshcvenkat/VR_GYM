using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class MovementCompare : MonoBehaviour
{

    [Header("-------LeftHand-------")]

    public Transform L_ForeArm;
    public Transform L_Hand;
    public float Difference;
    public bool IsCheck;
    public int L_counting = 0;

    [Header("-------RightHand-------")]

    public Transform R_ForeArm;
    public Transform R_Hand;
    public int R_counting = 0;
    private float R_Difference;
    private bool R_IsCheck;
    [Header("--------------")]

    public int score;
    public int timer;
    public TextMeshProUGUI note, firstset, nextworkout, secondset, thirdset;
    public health healthscript;
    public TextMeshProUGUI scoretext, TimerText, Lcount_text, Rcount_text;
    private bool uibool, left, right, scoreblock;
    public bool animatorbool = true,airsquartON;

    public static MovementCompare instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        note.enabled = true;
        firstset.enabled = false;
        nextworkout.enabled = false;
        secondset.enabled = false;
        thirdset.enabled = false;
        TimerText.enabled = false;
        animatorbool = true;
    }

    void Update()
    {
        HandsMovements();
        FirstSet();
        SecondSet();
        ThirdSet();
        ScoreUpdate();
       
    }
    public void HandsMovements()
    {
        // Left Hand Movement

        Difference = Vector3.Distance(L_ForeArm.position, L_Hand.position) * 100;
        if (!scoreblock)
        {
            if (Difference > 33 && Difference < 34 && !IsCheck)
            {
               
                IsCheck = true;

            }
            if (Difference >= 48 && IsCheck)
            {
                IsCheck = false;

                L_counting++;
                Lcount_text.text = "L:" + L_counting.ToString();
                left = true;

            }
        }



        // Right Hand Movement

        R_Difference = Vector3.Distance(R_ForeArm.position, R_Hand.position) * 100;
        if (!scoreblock)
        {
            if (R_Difference > 20 && R_Difference < 21 && !R_IsCheck)
            {

                R_IsCheck = true;

            }
            if (R_Difference >= 48 && R_IsCheck)
            {
                R_IsCheck = false;

                R_counting++;
                Rcount_text.text = "R:" + R_counting.ToString();
                right = true;

            }
        }
    }
    public void FirstSet()
    {
        if (L_counting == 5 && R_counting == 5 && !uibool)
        {
            animatorbool = false;
            uibool = true;
            note.enabled = false;
            firstset.enabled = true;

            scoreblock = true;
            Debug.Log("This is the correct workout");

            Debug.Log("Next set, wait for a 10 seconds");
            StartCoroutine(countdownTostart());
            StartCoroutine(workoutCount());


        }
    }
    public void SecondSet()
    {
        if (L_counting == 10 && R_counting == 10 && uibool)
        {
            uibool = false;
            secondset.enabled = true;
            animatorbool = false;
            scoreblock = true;
            StartCoroutine(countdownTostart());
            StartCoroutine(secondsetcount());
        }
    }
    public void ThirdSet()
    {
        if (L_counting == 15 && R_counting == 15)
        {

            Debug.Log("completed 3Set in this workout");

            animatorbool = false;
            thirdset.enabled = true;
            scoreblock = true;
            airsquartON = true;
        }

    }
    public void ScoreUpdate()
    {
        if (left == true && right == true)
        {
            healthscript.TakeDamge(1);
            score++;
            scoretext.text = score.ToString() + "/15";
            left = false;
            right = false;

        }
    }
    IEnumerator workoutCount()
    {

        yield return new WaitForSeconds(10);
        firstset.enabled = false;
        nextworkout.enabled = true;
        animatorbool = true;
        Debug.Log("Again, start the workout");
        left = true; 
        scoreblock = false;


        yield return new WaitForSeconds(12);
        nextworkout.enabled = false;
    }

    IEnumerator countdownTostart()
    {
        while (timer > 0)
        {
            TimerText.enabled = true;
            TimerText.text = timer.ToString();
            yield return new WaitForSeconds(1f);
            timer--;
        }


        TimerText.enabled = false;
        timer = 10;
    }
    IEnumerator secondsetcount()
    {
        yield return new WaitForSeconds(10);
        secondset.enabled = false;
        animatorbool = true;
        scoreblock = false;
    }
    
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(L_ForeArm.position, 0.1f);
        Gizmos.DrawWireSphere(L_Hand.position, 0.1f);
        Gizmos.DrawWireSphere(R_ForeArm.position, 0.1f);
        Gizmos.DrawWireSphere(R_Hand.position, 0.1f);
    }
   
}
