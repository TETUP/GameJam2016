using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptMenu : MonoBehaviour 
{
	//insertion TotalGame - script interscene
	private TotalGame totalGame;


	public GameObject firstMenu;
	public GameObject secondMenu;
	public GameObject thirdMenu;
	public GameObject fourthMenu;
	public GameObject fifthMenu;
	public GameObject boutonBack;

	public Text compteARebour;

	int intMenu;

	bool triggerCompte = false;
	float debutCompte = 0.0f;
	float compteur = 15.0f;
	float delay = 15.0f;
	int choixP1 = 0;
	int choixP2 = 0;
	int choixP3 = 0;
	int choixP4 = 0;

	//Choix du personnage pour chaque joueur
	int choixPersoP1 = 0;
	int choixPersoP2 = 0;
	int choixPersoP3 = 0;
	int choixPersoP4 = 0;

	//Tuto
	float goTime;
	bool goTimeON = false;

	// Use this for initialization
	void Start () 
	{
		//on appelle totalgame
		totalGame = TotalGame.GetInstance();

		CacheCache (); //on cache tout avant de chercher

		//on va demander à totalgame si le first menu a déjà été vu depuis le lancement du jeu
		intMenu = totalGame.GetMenu();

		if (intMenu != 1) //le joueur vient de lancer le jeu donc on lui présente le first menu
		{
			FirstMenuON();
		}
		else //le joueur avait déjà lancé le jeu, il revient sur le menu donc on passe direct au second menu
		{
			SecondMenuON ();
		}
			

	}
	
	// Update is called once per frame
	void Update () 
	{

		//TUTO
		if ((goTimeON == true) && Time.time >= (goTime + 5)) 
		{
			Application.LoadLevel ("Niveau1");
		}

		if (Input.GetButtonDown ("Submit"))
			BoutonOk ();

		if (intMenu == 3){


			//JOUEUR 1 APPUIE SUR LES GACHETTES
			if (Input.GetButtonDown ("Next1")) //le joueur 1 vient d'appuyer sur la fleche droite dans sélection perso
			{
				FlecheP1Droite ();
			}
			else if (Input.GetButtonDown ("Previous1"))  //le joueur 1 vient d'appuyer sur la fleche gauche dans sélection perso
			{
				FlecheP1Gauche ();
			}

			//JOUEUR 2 APPUIE SUR LES GACHETTES
			if (Input.GetButtonDown ("Next2")) //le joueur 2 vient d'appuyer sur la fleche droite dans sélection perso
			{
				FlecheP2Droite ();
			}
			else if (Input.GetButtonDown ("Previous2"))  //le joueur 2 vient d'appuyer sur la fleche gauche dans sélection perso
			{
				FlecheP2Gauche ();
			}

			//JOUEUR 3 APPUIE SUR LES GACHETTES
			if (Input.GetButtonDown ("Next3")) //le joueur 3 vient d'appuyer sur la fleche droite dans sélection perso
			{
				FlecheP3Droite ();
			}
			else if (Input.GetButtonDown ("Previous3"))  //le joueur 3 vient d'appuyer sur la fleche gauche dans sélection perso
			{
				FlecheP3Gauche ();
			}

			//JOUEUR 4 APPUIE SUR LES GACHETTES
			if (Input.GetButtonDown ("Next4")) //le joueur 4 vient d'appuyer sur la fleche droite dans sélection perso
			{
				FlecheP4Droite ();
			}
			else if (Input.GetButtonDown ("Previous4"))  //le joueur 4 vient d'appuyer sur la fleche gauche dans sélection perso
			{
				FlecheP4Gauche ();
			}

				
			if (Input.GetButtonDown ("Jump1")) {

				if (!triggerCompte) {
					//imageP1.GetComponent<Image> ().sprite = (Sprite)Resources.Load ("Resources/Sprites/Personnages/Perso01"); //Charge l'image du perso 1 pour le joueur 1

					debutCompte = Time.time;
					triggerCompte = true;
					choixP1++;
				} else if (choixP1 == 1) {
					PlayerPrefs.SetInt ("Choix_Player_1", choixPersoP1); //on enregistre le choix dans le player pref
					delay -= 2.0f; 
					Debug.Log ("Choix Joueur 1");
				} else if (choixP1 < 1) {
					choixP1++;
					delay += 2.0f; 
				}
			}
			if(Input.GetButtonDown ("Jump2")){
				//imageP2.GetComponent<Image> ().sprite = Resources.Load (); //Charge l'image du perso 1 pour le joueur 2
				if (!triggerCompte) {
					debutCompte = Time.time;
					triggerCompte = true;
					choixP2++;
				} else if (choixP2 == 1) {
					PlayerPrefs.SetInt("Choix_Player_2", choixPersoP2); //on enregistre le choix dans le player pref
					delay -= 2.0f; 
					Debug.Log ("Choix Joueur 2");
				} else if (choixP2 < 1) {
					choixP2++;
					delay += 2.0f; 
				}
			}
			if(Input.GetButtonDown ("Jump3")){
				//imageP3.GetComponent<Image> ().sprite = Resources.Load (); //Charge l'image du perso 1 pour le joueur 3
				if (!triggerCompte) {
					debutCompte = Time.time;
					triggerCompte = true;
					choixP3++;
				} else if (choixP3 == 1) {
					PlayerPrefs.SetInt("Choix_Player_3", choixPersoP3); //on enregistre le choix dans le player pref
					delay -= 2.0f; 
					Debug.Log ("Choix Joueur 3");
				} else if (choixP3 < 1) {
					choixP3++;
					delay += 2.0f; 
				}
			}
			if(Input.GetButtonDown ("Jump4")){
				//imageP4.GetComponent<Image> ().sprite = Resources.Load (); //Charge l'image du perso 1 pour le joueur 4
				if (!triggerCompte) {
					debutCompte = Time.time;
					triggerCompte = true;
					choixP4++;
				} else if (choixP4 == 1) {
					PlayerPrefs.SetInt("Choix_Player_4", choixPersoP4); //on enregistre le choix dans le player pref
					delay -= 2.0f; 
					Debug.Log ("Choix Joueur 4");
				} else if (choixP4 < 1) {
					choixP4++;
					delay += 2.0f; 
				}
			}
			if (triggerCompte) {
				compteur = debutCompte - Time.time + delay;
				compteARebour.text = "Choose your character " + Mathf.RoundToInt(compteur);
				if ((choixP1<1 || choixP1>1) && (choixP2<1 || choixP2>1) && (choixP3<1 || choixP3>1) && (choixP4<1 || choixP4>1)) //si tout le monde à choisi
					delay = 5.0f;
				if (compteur < 0.0f) {
					FourthMenuON ();
				}
					
			}
				
		}

		if (Input.GetButtonDown("Cancel"))
			BoutonBack();
	}

	public void CacheCache()//on cache tout ici, la fonction est appelée en start
	{
		firstMenu.SetActive (false);
		secondMenu.SetActive (false);
		thirdMenu.SetActive (false);
		fourthMenu.SetActive (false);
		fifthMenu.SetActive (false);
		intMenu = 0;
	}

	public void FirstMenuON()//On affiche le premier menu, allez savoir pourquoi...
	{
		CacheCache ();
		firstMenu.SetActive (true);
		boutonBack.SetActive (false);
		intMenu = 1;
		totalGame.SetMenu (intMenu); //on avertit le script interscene que le first menu a déjà été lancé
	}

	public void SecondMenuON()//le joueur revient sur le menu principal
	{
		CacheCache ();
		boutonBack.SetActive (false);
		secondMenu.SetActive (true);
		intMenu = 2;
	}

	public void ThirdMenuON()//Choix du personnage - Insérer ici la connexion des joueurs
	{
		CacheCache ();
		boutonBack.SetActive (true);
		thirdMenu.SetActive (true);
		intMenu = 3;
	}

	public void FourthMenuON()//Choix de l'arène
	{
		CacheCache ();
		boutonBack.SetActive (true);
		fourthMenu.SetActive (true);
		intMenu = 4;
	}

	public void FifthMenuON()
	{
		goTime = Time.time;
		CacheCache ();
		boutonBack.SetActive (false);
		fifthMenu.SetActive (true);
		intMenu = 5;
		goTimeON = true;
	}

	public void BoutonOk(){
		if (intMenu == 0) {
			FirstMenuON ();
		} else if (intMenu == 1) {
			SecondMenuON ();
		} else if (intMenu == 2) {
			ThirdMenuON ();
		} else if (intMenu == 4) {
			FifthMenuON ();
		}
	}

	public void BoutonBack()
	{
		if (intMenu == 2) {
			FirstMenuON ();
		} else if (intMenu == 3) {
			SecondMenuON ();
		} else if (intMenu == 4) {
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

	//FLECHES CHOIX PERSO

	//JOUEUR 1
	public void FlecheP1Droite()
	{
		if (choixPersoP1 < 3) 
		{
			choixPersoP1++;
			print (choixPersoP1);
		}
		else if (choixPersoP1 == 3)
		{
			choixPersoP1 = 0;
			print (choixPersoP1);
		}

	}
	public void FlecheP1Gauche()
	{
		if (choixPersoP1 > 0) 
		{
			choixPersoP1--;
			print (choixPersoP1);
		}
		else if (choixPersoP1 == 0)
		{
			choixPersoP1 = 3;
			print (choixPersoP1);
		}

	}
	//JOUEUR 2
	public void FlecheP2Droite()
	{
		if (choixPersoP2 < 3) 
		{
			choixPersoP2++;
		}
		else if (choixPersoP2 == 3)
		{
			choixPersoP2 = 0;
		}

	}
	public void FlecheP2Gauche()
	{
		if (choixPersoP2 > 0) 
		{
			choixPersoP2--;
		}
		else if (choixPersoP2 == 0)
		{
			choixPersoP2 = 3;
		}
	}
	//JOUEUR 3
	public void FlecheP3Droite()
	{
		if (choixPersoP3 < 3) 
		{
			choixPersoP3++;
		}
		else if (choixPersoP3 == 3)
		{
			choixPersoP3 = 0;
		}

	}
	public void FlecheP3Gauche()
	{
		if (choixPersoP3 > 0) 
		{
			choixPersoP3--;
		}
		else if (choixPersoP3 == 0)
		{
			choixPersoP3 = 3;
		}
	}
	//JOUEUR 4
	public void FlecheP4Droite()
	{
		if (choixPersoP4 < 3) 
		{
			choixPersoP4++;
		}
		else if (choixPersoP4 == 3)
		{
			choixPersoP4 = 0;
		}

	}
	public void FlecheP4Gauche()
	{
		if (choixPersoP4 > 0) 
		{
			choixPersoP4--;
		}
		else if (choixPersoP4 == 0)
		{
			choixPersoP4 = 3;
		}
	}

}
