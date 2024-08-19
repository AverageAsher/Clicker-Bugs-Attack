using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateMoney : MonoBehaviour
{
    public TMP_Text moneyText;

    private int money;

    public GameObject Upgrades;
    private int[] prices;
    private bool[] wearing;
    public Button[] buttons;

    void Start()
    {
        prices = new int[4];
        prices[0] = 50;
        prices[1] = 100;
        prices[2] = 200;
        prices[3] = 1000;

        wearing = new bool[4];
    }

    private void Update()
    {
        for (int i = 0; i < prices.Length; i++) 
        {
            if (money >= prices[i] && !wearing[i])
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }

    public void AddMoney()
    {
        money++;
        moneyText.text = "Money: " + money;
    }

    public void Buy(int num)
    {
        money -= prices[num];
        Upgrades.transform.GetChild(num).gameObject.SetActive(true);
        wearing[num] = true;
        moneyText.text = "Money: " + money;
    }

}
