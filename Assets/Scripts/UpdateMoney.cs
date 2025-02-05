using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpdateMoney : MonoBehaviour
{
    public TMP_Text moneyText;
    public GameObject bugPrefab; // Assign your bug prefab in the inspector
    public Transform bugSpawnPoint; // Assign the right middle of the screen as the spawn point
    public GameObject pauseButton;

    private int money;

    public GameObject Upgrades;
    private GameObject bugs;
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

        LoadProgress(); // Load saved progress on start
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
        SaveProgress(); // Save progress after money changes
    }

    public void Buy(int num)
    {
        // Ensure the previous upgrade has been purchased, except for the first upgrade
        if (num > 0 && !wearing[num - 1])
        {
            Debug.Log("You need to buy the previous upgrade first!");
            return;
        }

        // Check if the player has enough money to buy the upgrade
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

            SaveProgress(); // Save progress after buying an upgrade
            EventSystem.current.SetSelectedGameObject(pauseButton);
        }
        else
        {
            Debug.Log("Not enough money to buy this upgrade.");
        }
    }

    private void SpawnBugs()
    {
        bugs = Instantiate(bugPrefab, bugSpawnPoint.position, Quaternion.identity, bugSpawnPoint);
        // Add any additional logic for the bugs if needed
    }

    public void DeductMoney(int amount)
    {
        money -= amount;
        moneyText.text = "Money: " + money;
        SaveProgress(); // Save progress after money deduction
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetInt("Money", money);

        // Save wearing array as a string
        for (int i = 0; i < wearing.Length; i++)
        {
            PlayerPrefs.SetInt("Wearing" + i, wearing[i] ? 1 : 0);
        }

        // Save autoClickerActive status
        PlayerPrefs.SetInt("AutoClickerActive", autoClickerActive ? 1 : 0);

        PlayerPrefs.Save();
    }

    private void LoadProgress()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        moneyText.text = "Money: " + money;

        // Load wearing array
        for (int i = 0; i < wearing.Length; i++)
        {
            wearing[i] = PlayerPrefs.GetInt("Wearing" + i, 0) == 1;
            if (wearing[i])
            {
                Upgrades.transform.GetChild(i).gameObject.SetActive(true);
            }

            if (i == 1 && wearing[i]) SpawnBugs();
        }

        // Load autoClickerActive status
        autoClickerActive = PlayerPrefs.GetInt("AutoClickerActive", 0) == 1;
    }

    private void OnApplicationQuit()
    {
        SaveProgress(); // Ensure progress is saved when the game closes
    }

    // New method to reset progress
    public void ResetProgress()
    {
        Destroy(bugs);
        // Clear all saved data
        PlayerPrefs.DeleteAll();

        // Reset variables to default values
        money = 0;
        moneyText.text = "Money: " + money;

        autoClickerActive = false;
        autoClickerTimer = 0f;

        for (int i = 0; i < wearing.Length; i++)
        {
            wearing[i] = false;
            Upgrades.transform.GetChild(i).gameObject.SetActive(false);
        }

        // Disable all upgrade buttons
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }

        Debug.Log("Progress has been reset to default.");
    }
}
