using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyLoadUILevelLeftClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Ui");
    }

}
