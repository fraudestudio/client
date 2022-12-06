using Assets.Scripts.Village;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VillageManager : MonoBehaviour
{

    public GameObject villageCenterBlockPreFab;

    private static int countCharacterTrainingCamp = 0;
    private static int countCharacterTavern = 0;
    private static int countCharacterHealer = 0;

    private void Awake()
    {
        
        Village v = new Village("dsqfqesf", "qsdfqsd","ezaf") ;
        GameObject.Find("BuildingText").transform.Find("CanvasGunsmith").Find("GunsmithName").Find("GunsmithLevel").GetComponent<TMP_Text>().text = "Niveau " + Village.Gunsmith.Level;
        GameObject.Find("BuildingText").transform.Find("CanvasTrainingCamp").Find("TrainingCampName").Find("TrainingCampLevel").GetComponent<TMP_Text>().text = "Niveau " + Village.Gunsmith.Level;
        GameObject.Find("BuildingText").transform.Find("CanvasHealerHut").Find("HutName").Find("HutLevel").GetComponent<TMP_Text>().text = "Niveau " + Village.Gunsmith.Level;
        GameObject.Find("BuildingText").transform.Find("CanvasTavern").Find("TavernName").Find("TavernLevel").GetComponent<TMP_Text>().text = "Niveau " + Village.Tavern.Level;
        GameObject.Find("BuildingText").transform.Find("CanvasWarehouse").Find("WarehouseName").Find("WareHouseLevel").GetComponent<TMP_Text>().text = "Niveau " + Village.Warehouse.Level;
        GameObject.Find("BuildingText").transform.Find("CanvasHealerHut").Find("HutName").Find("HutLevel").GetComponent<TMP_Text>().text = "Niveau " + Village.HealerHut.Level;


        Transform villageCenterMenu = GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects");

        #region Tavern
        GameObject tavernButton = Instantiate(villageCenterBlockPreFab);
        tavernButton.name = "TavernButton";
        tavernButton.transform.SetParent(villageCenterMenu);
        tavernButton.transform.localScale = new Vector2(1, 1);
        tavernButton.transform.Find("BuildingTitle").GetComponent<TMP_Text>().text = "Taverne";

        if (Village.Tavern.InConstruction)
        {
            tavernButton.transform.Find("NotInConstructionTitle").gameObject.SetActive(false);
            tavernButton.transform.Find("TimeSliderCenter").gameObject.SetActive(true);
        }



        #endregion
        #region Gunsmith
        GameObject gunsmith = Instantiate(villageCenterBlockPreFab);
        gunsmith.name = "GunsmithButton";
        gunsmith.transform.SetParent(villageCenterMenu);
        gunsmith.transform.localScale = new Vector2(1, 1);
        gunsmith.transform.Find("BuildingTitle").GetComponent<TMP_Text>().text = "Armurier";

        if (Village.Gunsmith.InConstruction)
        {
            tavernButton.transform.Find("NotInConstructionTitle").gameObject.SetActive(false);
            tavernButton.transform.Find("TimeSliderCenter").gameObject.SetActive(true);
        }
        #endregion
        #region Warehouse
        GameObject warehouse = Instantiate(villageCenterBlockPreFab);
        warehouse.name = "WarehouseButton";
        warehouse.transform.SetParent(villageCenterMenu);
        warehouse.transform.localScale = new Vector2(1, 1);
        warehouse.transform.Find("BuildingTitle").GetComponent<TMP_Text>().text = "Entrepôt";
        warehouse.transform.Find("PeopleIcon").gameObject.SetActive(false);

        if (Village.Warehouse.InConstruction)
        {
            warehouse.transform.Find("NotInConstructionTitle").gameObject.SetActive(false);
            warehouse.transform.Find("TimeSliderCenter").gameObject.SetActive(true);
        }
        #endregion
        #region TrainingCamp
        GameObject trainingcamp = Instantiate(villageCenterBlockPreFab);
        trainingcamp.name = "TrainingCampButton";
        trainingcamp.transform.SetParent(villageCenterMenu);
        trainingcamp.transform.localScale = new Vector2(1, 1);
        trainingcamp.transform.Find("BuildingTitle").GetComponent<TMP_Text>().text = "Camp d'entraînement";
        trainingcamp.transform.Find("BuildingTitle").GetComponent<TMP_Text>().fontSize = 13;

        if (Village.TrainingCamp.InConstruction)
        {
            trainingcamp.transform.Find("NotInConstructionTitle").gameObject.SetActive(false);
            trainingcamp.transform.Find("TimeSliderCenter").gameObject.SetActive(true);
        }
        #endregion
        #region HealerHut
        GameObject healerhutButton = Instantiate(villageCenterBlockPreFab);
        healerhutButton.name = "HealerHutButton";
        healerhutButton.transform.SetParent(villageCenterMenu);
        healerhutButton.transform.localScale = new Vector2(1, 1);
        healerhutButton.transform.Find("BuildingTitle").GetComponent<TMP_Text>().text = "Hutte du guérisseur";
        healerhutButton.transform.Find("BuildingTitle").GetComponent<TMP_Text>().fontSize = 13;

        if (Village.HealerHut.InConstruction)
        {
            healerhutButton.transform.Find("NotInConstructionTitle").gameObject.SetActive(false);
            healerhutButton.transform.Find("TimeSliderCenter").gameObject.SetActive(true);
        }
        #endregion
    }

    private void Start()
    {
        #region Tavern

        Transform tavernButton = GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("TavernButton");

        if (Village.Tavern.InConstruction)
        {
           tavernButton.Find("TimeSliderCenter").gameObject.GetComponent<TimeLeftSliderScript>().Init(300, 500);
        }


        countCharacterTavern = 0;

        for (int i = 0; i < GameObject.Find("TavernMenu").transform.Find("HeroesAvaiable").childCount; i++)
        {
            if (!GameObject.Find("TavernMenu").transform.Find("HeroesAvaiable").GetChild(i).GetComponent<CharacterSlotScript>().slotIsEmpty)
            {
                countCharacterTavern++;
            }
        }

        tavernButton.transform.Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + countCharacterTavern;
        tavernButton.transform.Find("PeopleIcon").Find("TimeSliderSpecific").gameObject.SetActive(true);
        tavernButton.transform.Find("PeopleIcon").Find("TimeSliderSpecific").GetComponent<TimeLeftSliderScript>().Init(Convert.ToInt32(GameObject.Find("TavernMenu").transform.Find("TimeSliderTavern").GetComponent<Slider>().value), Convert.ToInt32(GameObject.Find("TavernMenu").transform.Find("TimeSliderTavern").GetComponent<Slider>().maxValue));
        #endregion
        #region Gunsmith
        Transform gunsmith = GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("GunsmithButton");

        if (Village.Tavern.InConstruction)
        {
            tavernButton.Find("TimeSliderCenter").gameObject.GetComponent<TimeLeftSliderScript>().Init(300, 500);
        }


        int countChar = 0;

        if (!GameObject.Find("GunsmithMenu").transform.Find("CharacterSlot").GetComponent<CharacterSlotScript>().SlotIsEmpty)
        {
            countChar = 1;
        }

        gunsmith.transform.Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + countChar;
        #endregion
        #region Warehouse
        Transform warehouse = GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("GunsmithButton");

        if (Village.Warehouse.InConstruction)
        {
            warehouse.Find("TimeSliderCenter").gameObject.GetComponent<TimeLeftSliderScript>().Init(300, 500);
        }

        #endregion
        #region TrainingCamp
        Transform trainingCamp = GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("TrainingCampButton");

        if (Village.TrainingCamp.InConstruction)
        {
            trainingCamp.Find("TimeSliderCenter").gameObject.GetComponent<TimeLeftSliderScript>().Init(300, 500);
        }


        for (int i = 0; i < GameObject.Find("TrainingCampMenu").transform.Find("TraineeTitle").Find("TraineesLayout").childCount; i++)
        {
            if (!GameObject.Find("TrainingCampMenu").transform.Find("TraineeTitle").Find("TraineesLayout").GetChild(i).GetComponent<CharacterSlotScript>().slotIsEmpty)
            {
                countCharacterTrainingCamp++;
            }
        }

        if (!GameObject.Find("TrainingCampMenu").transform.Find("InstructorTitle").Find("CharacterSlot").GetComponent<CharacterSlotScript>().slotIsEmpty)
        {
            countCharacterTrainingCamp++;
        }

        trainingCamp.transform.Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + countCharacterTrainingCamp;

        if (Village.TrainingCamp.InFormation)
        {
            trainingCamp.transform.Find("PeopleIcon").Find("TimeSliderSpecific").gameObject.SetActive(true);
            trainingCamp.transform.Find("PeopleIcon").Find("TimeSliderSpecific").GetComponent<TimeLeftSliderScript>().Init(Convert.ToInt32(GameObject.Find("TrainingCampMenu").transform.Find("TimeSliderTrainingCamp").GetComponent<Slider>().value), Convert.ToInt32(GameObject.Find("TrainingCampMenu").transform.Find("TimeSliderTrainingCamp").GetComponent<Slider>().maxValue));
        }

        #endregion
        #region HealerHut
        Transform healerHut = GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("HealerHutButton");

        if (Village.HealerHut.InConstruction)
        {
            healerHut.Find("TimeSliderCenter").gameObject.GetComponent<TimeLeftSliderScript>().Init(300, 500);
        }


        for (int i = 0; i < GameObject.Find("HealerHutMenu").transform.Find("SlotsHealer").childCount; i++)
        {
            if (!GameObject.Find("HealerHutMenu").transform.Find("SlotsHealer").GetChild(i).Find("CharacterSlot").GetComponent<CharacterSlotScript>().SlotIsEmpty)
            {
                countCharacterHealer++;
            }
        }

        healerHut.transform.Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + countCharacterHealer;



        #endregion
    }

    #region Observeurs

    public static void CharAddedTavern()
    {
        countCharacterTavern++;
        GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("TavernButton").Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + countCharacterTavern;
    }

    public static void CharRemovedTavern()
    {
        countCharacterTavern--;
        GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("TavernButton").Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + countCharacterTavern;
    }

    public static void TrainingStarted()
    {
        GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("TrainingCampButton").Find("PeopleIcon").Find("TimeSliderSpecific").gameObject.SetActive(true);
        GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("TrainingCampButton").Find("PeopleIcon").Find("TimeSliderSpecific").GetComponent<TimeLeftSliderScript>().Init(Convert.ToInt32(GameObject.Find("TrainingCampMenu").transform.Find("TimeSliderTrainingCamp").GetComponent<Slider>().maxValue), Convert.ToInt32(GameObject.Find("TrainingCampMenu").transform.Find("TimeSliderTrainingCamp").GetComponent<Slider>().maxValue));
    }

    public static void CharAddedTrainingCamp()
    {
        countCharacterTrainingCamp++;
        GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("TrainingCampButton").Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + countCharacterTrainingCamp;
    }

    public static void CharRemovedTrainingCamp()
    {
        countCharacterTrainingCamp--;
        GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("TrainingCampButton").Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + countCharacterTrainingCamp;
    }

    public static void CharAddedGunsmith()
    {
        GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("GunsmithButton").transform.Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + 1;
    }

    public static void CharRemovedGunsmith()
    {
        GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("GunsmithButton").transform.Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + 0;
    }

    public static void CharAddedHealer()
    {
        countCharacterHealer++;
        GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("HealerHutButton").Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + countCharacterHealer;
    }

    public static void CharRemovedHealer()
    {
        countCharacterHealer--;
        GameObject.Find("VillageCenterMenu").transform.Find("VillageCenterObjects").Find("HealerHutButton").Find("PeopleIcon").Find("CharacterCount").GetComponent<TMP_Text>().text = "x" + countCharacterHealer;
    }

    #endregion
}
