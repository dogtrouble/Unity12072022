using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public  GameObject    MyCharacter;
    private BaseCharacter myCharacterScript;
    public  Slider        thisSlider;

    private void Start()
    {
        myCharacterScript = MyCharacter.GetComponent<BaseCharacter>();

        if (myCharacterScript) 
        {
            myCharacterScript.damaged += updateSliderValue;
        }

        thisSlider        = this.GetComponent<Slider>();

        if (myCharacterScript
            && thisSlider) 
        {
            thisSlider.maxValue = myCharacterScript.maxHealth;
            thisSlider.minValue = 0;
            thisSlider.value    = myCharacterScript.health;
        }
    }

    private void updateSliderValue(int incomingDamage) 
    {
        if (thisSlider
        &&  myCharacterScript) 
        {
            thisSlider.value = myCharacterScript.health;
        }
    }
}
