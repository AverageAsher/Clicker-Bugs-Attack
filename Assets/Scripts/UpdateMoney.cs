using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateMoney : MonoBehaviour
{
    public TMP_Text moneyText;
    public GameObject bugPrefab; // Assign your bug prefab in the inspector
    public Transform bugSpawnPoint; // Assign the right middle of the screen as the spawn point

    private int money;

    public GameObject Upgrades;
    private int[] prices;
    private bool[] wearing;
    public Button[] buttons;

    private bool autoClickerActive;
    private float autoClickerInterval = 2f; // Interval in seconds
    private int autoClickerAmount = 20;     // Amount added per interval
    private float autoClickerTimer;

    void Start()
    {
        prices = new int[4];
        prices[0] = 50;
        prices[1] = 100;
        prices[2] = 200;
        prices[3] = 1000;

        wearing = new bool[4];
        autoClickerActive = false;
        autoClickerTimer = 0f;
    }

    private void Update()
    {
        // Handle button interactivity based on available money and upgrade status
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

        // Autoclicker functionality
        if (autoClickerActive)
        {
            autoClickerTimer += Time.deltaTime;
            if (autoClickerTimer >= autoClickerInterval)
            {
                money += autoClickerAmount;
                moneyText.text = "Money: " + money;
                autoClickerTimer = 0f;
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
        if (money >= prices[num])
        {
            money -= prices[num];
            Upgrades.transform.GetChild(num).gameObject.SetActive(true);
            wearing[num] = true;
            moneyText.text = "Money: " + money;

            // Activate autoclicker if the 200 upgrade is purchased
            if (num == 2) // Assuming the 200 upgrade is the third item in the array
            {
                autoClickerActive = true;
            }

            // Spawn bugs if the 100 upgrade is purchased
            if (num == 1) // Assuming the 100 upgrade is the second item in the array
            {
                SpawnBugs();
            }
        }
    }

    private void SpawnBugs()
    {
        GameObject bug = Instantiate(bugPrefab, bugSpawnPoint.position, Quaternion.identity, bugSpawnPoint);
        // Add any additional logic for the bugs if needed
    }

    public void DeductMoney(int amount)
    {
        money -= amount;
        moneyText.text = "Money: " + money;
    }
}
