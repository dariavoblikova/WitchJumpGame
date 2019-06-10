using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthDisplay : MonoBehaviour
{
    public int startingHealth = 20;
    public int currentHealth;
    public Text healthText;
    public AudioClip deathSound;
    private GameObject gameOverTextObject;

    // Start is called before the first frame update
    void Start()
    {
        gameOverTextObject = GameObject.Find("GameOverText");
        gameOverTextObject.SetActive(false);

        currentHealth = startingHealth;

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "POTIONS:" + currentHealth;

        if (Input.GetMouseButtonDown(0))
        {

            // If health already zero... restart level!
            if (currentHealth == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                return; // Reloads level
            }

            if (currentHealth > 0)
            {
                currentHealth--;

                if (currentHealth == 0)
                {
                    GameObject.Find("ScoreDisplay").SetActive(false);
                    gameOverTextObject.SetActive(true);

                    //  She screams!
                    GetComponent<AudioSource>().PlayOneShot(deathSound, 1f);
                    //  Burn the witch!
                    GameObject.Find("Witch").SetActive(false);
                }
            }
            else
            {
                currentHealth = 0;
            }

        }

    }
}
