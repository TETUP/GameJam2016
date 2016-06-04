using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptMenu : MonoBehaviour 
{

	public GameObject firstMenu;
	public GameObject secondMenu;
	public GameObject thirdMenu;
	public GameObject fourthMenu;
	public GameObject boutonBack;

	int intMenu;
	bool firstMenuBool = true;



	// Use this for initialization
	void Start () 
	{
		CacheCache ();
		firstMenu.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((firstMenuBool == true) && Input.GetButton("Fire1"))
		{
			SecondMenuON ();
			firstMenuBool = false;
		}
	}

	public void CacheCache()//on cache tout ici, la fonction est appelée en start
	{
		firstMenu.SetActive (false);
		secondMenu.SetActive (false);
		thirdMenu.SetActive (false);
		fourthMenu.SetActive (false);
		intMenu = 0;
	}

	public void FirstMenuON()//On affiche le premier menu, allez savoir pourquoi...
	{
		CacheCache ();
		firstMenu.SetActive (true);
		intMenu = 1;
		firstMenuBool = true;
	}

	public void SecondMenuON()//le joueur revient sur le menu principal
	{
		CacheCache ();
		boutonBack.SetActive (true);
		secondMenu.SetActive (true);
		intMenu = 2;
	}

	public void ThirdMenuON()//Choix du personnage - Insérer ici la connexion des joueurs
	{
		CacheCache ();
		thirdMenu.SetActive (true);
		intMenu = 3;
	}

	public void FourthMenuON()//Choix de l'arène
	{
		CacheCache ();
		fourthMenu.SetActive (true);
		intMenu = 4;
	}

	public void BoutonBack()
	{
		if (intMenu == 2) 
		{
			FirstMenuON ();
			boutonBack.SetActive (false);
		} 
		else if (intMenu == 3) 
		{
			SecondMenuON ();
		} 
		else if (intMenu == 4) 
		{
			ThirdMenuON ();
		}
	}

	public void GoJouer()//lance la partie après le choix de l'arène
	{
		Application.LoadLevel ("Niveau1");
	}
	public void Quitter()//Quitte le jeu sur pc, et met en arrière plan sur tablette et téléphone
	{
		Application.Quit ();
	}
}
