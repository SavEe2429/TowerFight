using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [Header("UI Ref")]
    public TextMeshProUGUI woodText;

    [Header("Current Resources")]
    public int currentWood = 0;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {

        UpdateUI();
    }


    public void AddWood(int amount)
    {
        currentWood += amount;
        Debug.Log($"currentWood: {currentWood}");
        UpdateUI();
    }

    void UpdateUI()
    {
        if (woodText != null)
        {
            woodText.text = "Wood: " + currentWood.ToString();
        }
    }
}
