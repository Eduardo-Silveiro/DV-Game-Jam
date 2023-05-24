using UnityEngine;

/// <summary>
/// Controls the activation of fruits in the game.
/// </summary>
public class ActivateFruits : MonoBehaviour
{
    [SerializeField] private GameObject[] fruits;
    [SerializeField] private GameData gameData;
    private GameObject activeFruit;

    private void Start()
    {
        gameData.ActiveFruits = 0;

        foreach (GameObject fruit in fruits)
        {
            fruit.SetActive(false);
        }
    }

    private void Update()
    {
        if (gameData.ActiveFruits == 0)
        {
            ShowFruits();
        }
    }

    /// <summary>
    /// Shows a random fruit by activating it.
    /// </summary>
    private void ShowFruits()
    {
        int randomIndex = Random.Range(0, fruits.Length);
        activeFruit = fruits[randomIndex];
        activeFruit.SetActive(true);
        gameData.ActiveFruits++;
    }
}