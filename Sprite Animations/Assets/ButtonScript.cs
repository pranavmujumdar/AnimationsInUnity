using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour
{
    public void nextLevel()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
