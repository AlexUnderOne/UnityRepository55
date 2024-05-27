using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] Button[] buyButton;
    [SerializeField] TextMeshProUGUI[] buyText;
    [SerializeField] int[] Prices;

    [SerializeField] GameObject shopPanel;

    private void Start()
    {
        
        for (int i = 0; i < buyButton.Length; i++)
        {
            if (!PlayerPrefs.HasKey("Position" + i))
            {
                PlayerPrefs.SetInt("Position" + i , 0);
                buyButton[i].interactable = true;
                buyText[i].text = "Купить";
            }
            else
            {
                if (PlayerPrefs.GetInt("Position" + i) == 1)
                {
                    buyButton[i].interactable = false;
                    buyText[i].text = "Приобретено";
                }
            }
        }
        Check();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Check();
            
            shopPanel.SetActive(!shopPanel.activeInHierarchy); 
            

            if (shopPanel.activeInHierarchy)
            {
                Time.timeScale = 0;
            }
            else Time.timeScale = 1;
        }
    }


 
    public void Buy(int index)
    {
        buyButton[index].interactable = false;
        buyText[index].text = "Приобретено";

        PlayerPrefs.SetInt("Position" + index , 1);
    }
    void Check()
    {
        
        for (int i = 0; i < buyButton.Length; i++)
        {
            if (PlayerPrefs.GetInt("Position" + i) == 1) break;


            if (ScriptTwo.instance.currentMoney >= Prices[i])
            {
                buyButton[i].interactable = true;
                //
                buyText[i].text = "Купить";
            }
            else
            {
                buyButton[i].interactable = false;
                //buyText[i].text = "Купить";
                buyText[i].text = "Мало монет";
            }
        }

    }

    [ContextMenu("Delete Player Prefs")]
    void DeletePlayerPrefs() => PlayerPrefs.DeleteAll();
}
