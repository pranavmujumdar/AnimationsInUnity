using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Collectibles : MonoBehaviour
{
    public TextMeshProUGUI collectiblesText;
    public static int levelCollectibles = 1;
    public Animator animator;
    public static int collected = 0;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            FindObjectOfType<AudioManager>().Play("Lighting");
            FindObjectOfType<AudioManager>().Play("Smoking");
            animator.SetTrigger("smoke");
            collected += 1;
            setCollectedText();
            Destroy(collision.gameObject);
            ScoreScript.scoreValue += 10;
        }
        
    }
    void setCollectedText()
    {
        collectiblesText.text = "Collected: " + collected + "/" + levelCollectibles; 
    }
}
