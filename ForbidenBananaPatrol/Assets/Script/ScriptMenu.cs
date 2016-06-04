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
	public GameObject boutonBack;
	public GameObject imageP1;
	public GameObject imageP2;
	public GameObject imageP3;
	public GameObject imageP4;
	public Text compteARebour;

	int intMenu;

	bool triggerCompte = false;
	float debutCompte = 0.0f;
	float compteur = 15.0f;
	float delay  =15.0f;
	int choixP1 = 0;
	int choixP2 = 0;
	int choixP3 = 0;
	int choixP4 = 0;

	// Use this for initialization
	void Start () 
	{
		//on appelle totalgame
		totalGame = TotalGame.GetInstance();

		CacheCache (); //on cache tout avant de chercher

		//on va demander à totalgame si le first menu a déjà été vu
		intMenu = totalGame.GetMenu();

		if (intMenu != 1) 
		{
			FirstMenuON();
		}
		else 
		{
			SecondMenuON ();
		}
			

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Submit"))
			BoutonOk ();

		if (intMenu == 3){
			if(Input.GetButtonDown ("Jump1")){
				//imageP1.GetComponent<Image> ().sprite = Resources.Load (); //Charge l'image du perso 1 pour le joueur 1
				if (!triggerCompte) {
					debutCompte = Time.time;
					triggerCompte = true;
					choixP1++;
				} else if (choixP1 == 1) {
					//enregistré le choix dans le player pref
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
					//enregistré le choix dans le player pref
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
					//enregistré le choix dans le player pref
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
					//enregistré le choix dans le player pref
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

	public void BoutonOk(){
		if (intMenu == 0)
		{
			FirstMenuON ();
		}
		else if (intMenu == 1)
		{
			SecondMenuON ();
		}
		else if (intMenu == 2)
		{
			ThirdMenuON ();
		}
		else if (intMenu == 4)
		{
			GoJouer ();
		}
	}

	public void BoutonBack()
	{
		if (intMenu == 2) 
		{
			FirstMenuON ();
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
