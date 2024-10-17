using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int moneyvalue = 500;
    public TextMeshProUGUI moneytext;
    public GameObject gameOverPanel;
    public GameObject WinnOverPanel;

    void Start()
    {
        UpdateMoneyText();
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        UpdateMoneyText();
    }

    public void AddMoney(int amount)
    {
        moneyvalue += amount;
        UpdateMoneyText();
    }

    void UpdateMoneyText()
    {
        if (moneytext != null)
        {
            moneytext.text = moneyvalue.ToString();
        }

        if (moneyvalue <= 0)
        {
            gameOverPanel.SetActive(true);
        }

        if (moneyvalue >= 600)
        {
            WinnOverPanel.SetActive(true);
        }
    }
}