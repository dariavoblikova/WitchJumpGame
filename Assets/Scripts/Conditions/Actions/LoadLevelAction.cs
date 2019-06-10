using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[AddComponentMenu("Playground/Actions/Load Level")]
public class LoadLevelAction : Action
{
    public string levelName = SAME_SCENE;

    public const string SAME_SCENE = "0";
    private static ILogger logger = Debug.unityLogger;
    private static string genericLevelName = "Level";


    //Loads a new Unity scene, or reload the current one (it means all objects are reset)
    public override bool ExecuteAction(GameObject dataObject)
    {

        //load next level
        string levelString = SceneManager.GetActiveScene().name;

        int currentLevelNumber = (int)System.Char.GetNumericValue(levelString[levelString.Length - 1]);
        currentLevelNumber += 1;

        string nextLevelString = genericLevelName + currentLevelNumber;


        logger.Log("Attempting to load: " + nextLevelString);
        SceneManager.LoadScene(nextLevelString, LoadSceneMode.Single);

        return true;
    }
}