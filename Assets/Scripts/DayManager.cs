using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text descriptionText;
    
    public bool IsDay = false;

    private float dayDuration = 30f;
    private float nightDuration = 60f;
    private Camera mainCamera;
    
    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(DayNightCycle());
    }

    IEnumerator DayNightCycle()
    {
        while (true)
        {
            // noite
            StartNight();
            yield return new WaitForSeconds(nightDuration);

            // dia
            StartDay();
            yield return new WaitForSeconds(dayDuration);

            IsDay = !IsDay;
        }
    }

    public void StartNight()
    {
        
        mainCamera.backgroundColor = IsDay ? Color.blue : Color.black;
        descriptionText.text = "Werewolfs can kill.";
    }

    public void StartDay()
    {
        mainCamera.backgroundColor = IsDay ? Color.black : Color.blue;
        descriptionText.text = "Who is the werewolf?";
    }

    public void ChangeToDetectiveText()
    {
        descriptionText.text = "Detective can try find the werewolf";
    }
}
