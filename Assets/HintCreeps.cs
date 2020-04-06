using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintCreeps : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hint;
    public CreateMobs mobs;
    public Text text;

    private void Start()
    {
        mobs = FindObjectOfType<CreateMobs>();
        text = hint.GetComponentInChildren<Text>();
    }




    public void OnPointerEnter(PointerEventData eventData)
    {
        string buttonName = eventData.pointerEnter.name;
        text.text = "Price: " + mobs.prices[short.Parse(buttonName)] + Environment.NewLine + "Income: " + mobs.incomes[short.Parse(buttonName)];
        hint.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hint.SetActive(false);
    }

}
