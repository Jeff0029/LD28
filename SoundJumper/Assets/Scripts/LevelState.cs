using UnityEngine;
using System.Collections;

public enum Level
{
    level1 = 0,
    level2,
    level3,
    level4,
    menu,
    exit
}

public class LevelState : MonoBehaviour {

    public static Level levelState;
    public static Level SetLevelState
    {
        set 
        { 
            levelState = value;
            ChangeLevel(levelState);
        }

        get { return levelState; }
    }


	
    static void ChangeLevel(Level levelState)
    {
        switch(levelState)
        {
            case Level.level1:
                levelState = Level.level1;
                Application.LoadLevel("Level1");
                break;
            case Level.level2:
                levelState = Level.level2;
                Application.LoadLevel("Level2");
                break;
            case Level.level3:
                levelState = Level.level3;
                Application.LoadLevel("Level3");
                break;
            case Level.level4:
                levelState = Level.level4;
                Application.LoadLevel("Level4");
                break;
            case Level.menu:
                levelState = Level.menu;
                Application.LoadLevel("menu");
                break;
            case Level.exit:
                Application.Quit();
                break;
        }
    }
}
