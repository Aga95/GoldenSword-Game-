using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
    public class WeaponButton : MonoBehaviour
    {

        public Movement player;
        public MoneyManager moneyM;
        public int weaponNumber;

        public Text name;
        public Text cost;
        public Text description;

        private AudioSource source;
        /*
        // Use this for initialization
        void Start()
        {
            source = GetComponent<AudioSource>();
            SetButton();
        }

        void SetButton()
        {
            //string costString = player.weapons[weaponNumber].cost.ToString();
            name.text = player.weapons[weaponNumber].name;
            cost.text = "$" + player.weapons[weaponNumber].cost;
            description.text = player.weapons[weaponNumber].description;
        }

        public void OnClick()
        {
            if (moneyM.currentGold >= player.weapons[weaponNumber].cost)
            {
                moneyM.currentGold -= player.weapons[weaponNumber].cost;
                player.currentWeapon = weaponNumber;
            }
            else
            {
                source.Play();
                Debug.Log("You don't have enough coins");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }*/
    }
}
