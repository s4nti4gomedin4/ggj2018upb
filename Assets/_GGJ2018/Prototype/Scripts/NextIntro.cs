using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextIntro : MonoBehaviour {

    public  System.Action onIntroEnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Next()
	{
		if (MainMenu.instance.actualSlide == MainMenu.IntroSlides.intro1) {
			MainMenu.instance.actualSlide = MainMenu.IntroSlides.intro2;
		} else if (MainMenu.instance.actualSlide == MainMenu.IntroSlides.intro2) {
			MainMenu.instance.actualSlide = MainMenu.IntroSlides.intro3;
		} else if (MainMenu.instance.actualSlide == MainMenu.IntroSlides.intro3) {
            if(onIntroEnd!=null){
                onIntroEnd();
            }
		}
	}
}
