using UnityEngine;
using System.Collections;

public class TotalGame
{

    public int score;
	public int menuInt;

    private TotalGame()
    {
        score = 0;
		menuInt = 0;
    }

    private static TotalGame instance;

    public static TotalGame GetInstance()
    {
        if (instance == null)
        {
            instance = new TotalGame();
        }

        return instance;

        //et là on balance le bordel

    }

    //SCORE
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int scorePlayer)
    {
        score = scorePlayer;
    }

	//CHOIX DU MENU
	public int GetMenu()
	{
		return menuInt;
	}
	public void SetMenu(int menuSequenceInt)
	{
		menuInt = menuSequenceInt;
	}
}
