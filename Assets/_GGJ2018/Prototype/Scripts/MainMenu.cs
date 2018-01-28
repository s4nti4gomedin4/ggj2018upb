using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject[] intros;
    public static System.Action OnGameStart;
    public NextIntro m_LastIntro;
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
        m_LastIntro.onIntroEnd += OnIntroEndHandler;
	}

    private void OnIntroEndHandler()
    {
        actualSlide = IntroSlides.end;
        if (OnGameStart != null)
        {
            OnGameStart();
        }
    }



    // Update is called once per frame
    void Update () {

		intros [0].SetActive (actualSlide == IntroSlides.mainMenu ? true: false);
		intros [1].SetActive (actualSlide == IntroSlides.intro1 ? true: false);
		intros [2].SetActive (actualSlide == IntroSlides.intro2 ? true: false);
		intros [3].SetActive (actualSlide == IntroSlides.intro3 ? true: false);
       
        if (Input.anyKeyDown || Input.GetMouseButtonDown (0)) {
			OnIntroEndHandler();
//            if (actualSlide == IntroSlides.mainMenu)
//            {
//                actualSlide = IntroSlides.intro1;
//            }else if (actualSlide == IntroSlides.intro1) {
//				actualSlide = IntroSlides.intro2;
//			} else if (actualSlide == IntroSlides.intro2) {
//				actualSlide = IntroSlides.intro3;
//			}else if(actualSlide == IntroSlides.intro3)
//			{
//                OnIntroEndHandler();
//			}
		}
	}

	public void StartBtn()
	{
		actualSlide = IntroSlides.intro1;
	}
		
}
