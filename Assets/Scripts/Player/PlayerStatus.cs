using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float Health;
    private  float Stemina;
    private float Hunger;
    private float Thirsty;
    private float Mental;

    public  void ChangeHealth(float health)
    {
        Health += health;
    }

    public  void ChangeStemina(float stemina)
    {
        Stemina += stemina;
    }

    public  void ChangeHunger(float hunger)
    {
        Hunger += hunger;
    }

    public  void ChangeThirsty(float thirsty)
    {
        Thirsty += thirsty;
    }

    public  void ChangeMental(float mental)
    {
        Mental += mental;
    }
}
