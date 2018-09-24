using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{ 
    public class MoneyManager : MonoBehaviour {

        public Text moneyText;
        public float currentGold;

	    // Use this for initialization
	    void Start () {

            if (PlayerPrefs.HasKey("CurrentMoney"))
            {
                currentGold = PlayerPrefs.GetFloat("CurrentMoney");
            }
            else
            {
                currentGold = 0;
                PlayerPrefs.SetFloat("CurrentMoney", 0);
            }

            moneyText.text = currentGold + " x";
        }
	
	    // Update is called once per frame
	    void Update () {
            if (Input.GetKeyDown(KeyCode.F7))
            {
                AddMoney(25);
            }
	    }

        public void AddMoney(int goldToAdd)
        {
            currentGold += goldToAdd;
            PlayerPrefs.SetFloat("CurrentMoney", currentGold);
            moneyText.text = currentGold + " x";
        }
        public void removeMoney(float amont)
        {
            currentGold -= amont;
            PlayerPrefs.SetFloat("CurrentMoney", currentGold);
            moneyText.text = currentGold + " x";
        }
        //Used to check current amount of money on the player
        public float getMoneyAmount()
        {
            return currentGold;
        }
        //Usend when u charge the player money.
        public void spendMoney(float amount)
        {
            removeMoney(amount);
        }

    }
}