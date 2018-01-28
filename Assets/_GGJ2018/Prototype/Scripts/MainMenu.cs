using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject[] intros;
    public static System.Action OnGameStart;
	public enum IntroSlides
	{
		mainMenu,
		intro1,
		intro2,
		intro3,
        end
	};

	public IntroSlides actualSlide;

	public static MainMenu instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {

		intros [0].SetActive (actualSlide == IntroSlides.mainMenu ? true: false);
		intros [1].SetActive (actualSlide == IntroSlides.intro1 ? true: false);
		intros [2].SetActive (actualSlide == IntroSlides.intro2 ? true: false);
		intros [3].SetActive (actualSlide == IntroSlides.intro3 ? true: false);

		if (Input.anyKeyDown || Input.GetMouseButtonDown (0)) {
			if (actualSlide == IntroSlides.intro1) {
				actualSlide = IntroSlides.intro2;
			} else if (actualSlide == IntroSlides.intro2) {
				actualSlide = IntroSlides.intro3;
			}else if(actualSlide == IntroSlides.intro3)
			{
                actualSlide = IntroSlides.end;
                if(OnGameStart!=null){
                    OnGameStart();
                }
			}
		}
	}

	public void StartBtn()
	{
		actualSlide = IntroSlides.intro1;
	}
		
}
