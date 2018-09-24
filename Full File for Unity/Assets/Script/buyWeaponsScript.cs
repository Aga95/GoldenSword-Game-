using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyWeaponsScript : MonoBehaviour {

    public MoneyManager moneyManager;
    private bool boughtW2, boughtW3, boughtW4;
    public GameObject sword, c2, c3, c4, textOutPut, textOutPutHP;
    public Sprite w1, w2, w3, w4;
    private SpriteRenderer spriteR;

    private void Start()
    {
        if (PlayerPrefs.GetInt("W2") > 0)
        {
            boughtW2 = true;
            c2.GetComponent<Text>().text = "owned";
        }
        else
        {
            boughtW2 = false;
        }
        if (PlayerPrefs.GetInt("W3") > 0)
        {
            boughtW3 = true;
            c3.GetComponent<Text>().text = "owned";
        }
        else
        {
            boughtW3 = false;
        }
        if (PlayerPrefs.GetInt("W4") > 0)
        {
            boughtW4 = true;
            c4.GetComponent<Text>().text = "owned";
        }
        else
        {
            boughtW4 = false;
        }
    }
    public void buyWeapon2()
    {
        float cost = 50;
        if (moneyManager.getMoneyAmount() > cost && !boughtW2)
        {
            boughtW2 = true;
            moneyManager.spendMoney(cost);
            PlayerPrefs.SetInt("W2", 1);
            c2.GetComponent<Text>().text = "owned";
        }
        else if (boughtW2)
        {
            eqiupW2();
        }
        else
        {
            textOutPut.GetComponent<Text>().text = "You dont have the money for this right now";
        }
    }
    public void buyWeapon3()
    {
        float cost = 250;
        if (moneyManager.getMoneyAmount() > cost && !boughtW3)
        {
            boughtW3 = true;
            moneyManager.spendMoney(cost);
            PlayerPrefs.SetInt("W3", 1);
            c3.GetComponent<Text>().text = "owned";
        }
        else if (boughtW3)
        {
            eqiupW3();

        }
        else
        {
            textOutPut.GetComponent<Text>().text = "You dont have the money for this right now";
        }

    }
    public void buyWeapon4()
    {
        float cost = 666;
        if (moneyManager.getMoneyAmount() > cost && !boughtW4)
        {
            boughtW4 = true;
            moneyManager.spendMoney(cost);
            PlayerPrefs.SetInt("W4", 1);
            c4.GetComponent<Text>().text = "owned";
        }
        else if (boughtW4)
        {
            eqiupW4();
        }
        else
        {
            textOutPut.GetComponent<Text>().text = "You dont have the money for this right now";
        }

    }
    public void buyHealthPotion()
    {
        float cost = 20;
        if (moneyManager.getMoneyAmount() > cost && PlayerPrefs.GetInt("healthPotions") <= 100)
        {
            moneyManager.spendMoney(cost);
            int tmp = PlayerPrefs.GetInt("healthPotions");
            tmp++;
            PlayerPrefs.SetInt("healthPotions", tmp);
            GameObject player = GameObject.Find("Player");
            player.GetComponent<Movement>().updateHealthPotions();
        }
        else if (PlayerPrefs.GetInt("healthPotions") >= 100)
        {
            textOutPutHP.GetComponent<Text>().text = "You cant carry any more healthpotions";
        }
        else
        {
            textOutPutHP.GetComponent<Text>().text = "You dont have the money for this right now";
        }
    }
    public void eqiupW1()
    {
        textOutPut.GetComponent<Text>().text = "Equiped";
        spriteR = sword.GetComponent<SpriteRenderer>();
        sword.GetComponent<swordScript>().damage = 2;
        spriteR.sprite = w1;
        PlayerPrefs.SetString("Wep", "W1");
    }
    private void eqiupW2()
    {
        textOutPut.GetComponent<Text>().text = "Equiped";
        spriteR = sword.GetComponent<SpriteRenderer>();
        sword.GetComponent<swordScript>().damage = 5;
        spriteR.sprite = w2;
        PlayerPrefs.SetString("Wep", "W2");
    }
    private void eqiupW3()
    {
        textOutPut.GetComponent<Text>().text = "Equiped";
        spriteR = sword.GetComponent<SpriteRenderer>();
        sword.GetComponent<swordScript>().damage = 10;
        spriteR.sprite = w3;
        PlayerPrefs.SetString("Wep", "W3");

    }
    private void eqiupW4()
    {
        textOutPut.GetComponent<Text>().text = "Equiped";
        spriteR = sword.GetComponent<SpriteRenderer>();
        sword.GetComponent<swordScript>().damage = 20;
        PlayerPrefs.SetString("Wep","W4");
        spriteR.sprite = w4;

    }
}
