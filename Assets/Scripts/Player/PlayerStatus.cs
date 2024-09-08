using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static float Health;
    public static float Stemina;
    public static float Hunger;
    public static float Thirsty;
    public static float Mental;

    public static void ChangeHealth(float health)
    {
        Health += health;
    }

    public static void ChangeStemina(float stemina)
    {
        Stemina += stemina;
    }

    public static void ChangeHunger(float hunger)
    {
        Hunger += hunger;
    }

    public static void ChangeThirsty(float thirsty)
    {
        Thirsty += thirsty;
    }

    public static void ChangeMental(float mental)
    {
        Mental += mental;
    }
}
