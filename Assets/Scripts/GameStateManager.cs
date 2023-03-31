using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager: MonoBehaviour
{   
    
    
    private static int NumberOfEnemies;
    private static int Level = 0;



    public void Start()
    {
        DontDestroyOnLoad(gameObject);
       
    }


    public static void SetNumberOfEnemies(int numberOfEnemies)
    {
        NumberOfEnemies = numberOfEnemies;
    }
    public static void DecraseNumberOfEnemies()
    {
        NumberOfEnemies -= 1;
    }
    public static void CheckIfLevelFinished()
    {

        Debug.Log("LEVEL" + Level);
        if (NumberOfEnemies == 0) {
            Level += 1;
            if (Level == 2)
            {
                Application.Quit();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public static int GetNumberOfEnemies()
    {
        return NumberOfEnemies;
    }
}
