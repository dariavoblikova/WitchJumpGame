using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int startingHealth = 5;
    public int currentHealth;
    public Text healthText;


    // Start is called before the first frame update
    void Start()
    {
    currentHealth = startingHealth;
}

    // Update is called once per frame
    void Update()
{
    healthText.text = "POTIONS: " + currentHealth;

    if (Input.GetMouseButtonDown(0))
    {
        if (currentHealth > 0)
        {
            currentHealth--;
        }

        else {
                currentHealth = 0;
                }
    }

}
}
