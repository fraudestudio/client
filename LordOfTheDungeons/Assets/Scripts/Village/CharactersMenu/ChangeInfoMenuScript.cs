using Assets.Scripts.Village;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInfoMenuScript : MonoBehaviour
{
    public Image Image;
    public TMP_Text Name;
    public TMP_Text Race;
    public TMP_Text Niveau;
    public TMP_Text Class;
    public TMP_Text PA;
    public TMP_Text PM;
    public TMP_Text Life;


    public Image WeaponImage;
    public TMP_Text WeaponName;
    public TMP_Text WeaponLevel;
    public TMP_Text WeaponPower;


    public Image ArmorImage;
    public TMP_Text ArmorName;
    public TMP_Text ArmorLevel;
    public TMP_Text ArmorResistance;

    public void ChangeInfoMenu (Character c)
    {
        Image.sprite = c.Image;
        Name.text = c.Name;
        Race.text = "Race : " + c.Race;
        Niveau.text = "Niveau : " + c.Level;
        PA.text = "PA MAX : " + c.PA_MAX;
        PM.text = "PM MAX : " + c.PM_MAX;
        Life.text = "Life : " + c.Life +"/"+c.MaxLife;
        Class.text = "Classe : " + c.Classe;

        WeaponImage.sprite = c.Weapon.Image;
        WeaponName.text = c.Weapon.Name;
        WeaponLevel.text = "Level : " + c.Weapon.Level;
        WeaponPower.text = "Puissance : " + c.Weapon.GetTotalPower();


        ArmorImage.sprite = c.Armor.Image;
        ArmorName.text = c.Armor.Name;
        ArmorLevel.text = "Level : " + c.Armor.Level;
        ArmorResistance.text = "Résistance  : " + c.Armor.GetTotalResistance();
    }
}
