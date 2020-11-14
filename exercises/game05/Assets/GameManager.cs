using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UnitScript selectedUnit;

    public GameObject namePanel;
    public Text nameText;
    public MeterScript healthMeter;
    public MeterScript ammoMeter;

    //public Image healthImage;
    //public Image ammoImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoButtonClicked()
    {
        if (selectedUnit != null)
        {
            selectedUnit.StartFollowingPath();
        }
    }

    public void SelectUnit(UnitScript toSelect)
    {
        selectedUnit = toSelect;

        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");

        for (int i = 0; i < units.Length; i++)
        {
            UnitScript unitScript = units[i].GetComponent<UnitScript>();
            unitScript.selected = true;
            unitScript.UpdateVisuals();
        }


        if (toSelect != null)
        {
            selectedUnit.selected = true;

            UpdateUI(selectedUnit);

            selectedUnit.UpdateVisuals();
        }
        else
        {
            namePanel.SetActive(true);
        }
    }

    public void UpdateUI(UnitScript unit)
    {
        healthMeter.SetMeter(unit.health / 100f);
        ammoMeter.SetMeter(unit.ammo / 18f);
        //healthImage.fillAmount = unit.health / 100f;
        //ammoImage.fillAmount = unit.ammo / 18f;
        nameText.text = unit.unitName;
        namePanel.SetActive(true);
    }
}

