using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float currentTime = 0f;
    public float levelTime = 15f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = levelTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        Invoke("setTimerText", 0.5f);
        if (CheckTimer())
        {
            FindObjectOfType<AudioManager>().Stop("Footstep");
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
    void setTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }
    bool CheckTimer()
    {
        if (currentTime <= 0)
        {
            Debug.Log("You Lost!");
            return true;
        }
        else
        {
            return false;
        }
    }
}
