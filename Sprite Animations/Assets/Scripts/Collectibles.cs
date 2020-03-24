using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Collectibles : MonoBehaviour
{
    public TextMeshProUGUI collectiblesText;
    public static int levelCollectibles = 3;
    public Animator animator;
    public static int collected = 0;
    private bool pickedUp = false;
    // Start is called before the first frame update
    private void Awake()
    {
        collected = 0;
    }
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
            if (!pickedUp)
            {
                pickedUp = true;
                Debug.Log("pipe");
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("Lighting");
                FindObjectOfType<AudioManager>().Play("Smoking");
                animator.SetTrigger("smoke");
                collected += 1;
                setCollectedText();
                ScoreScript.scoreValue += 10;
                Invoke("SetPickedUpFalse", 0.2f);
            }
            
        }
        
    }
    void setCollectedText()
    {
        collectiblesText.text = "Collected: " + collected + "/" + levelCollectibles; 
    }
    void SetPickedUpFalse()
    {
        pickedUp = false;
    }
}
