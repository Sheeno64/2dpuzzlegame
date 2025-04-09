
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] levels;
    public int currentLevel = 0;
    public WinUI winUI;

    void Start()
    {
        LoadLevel(currentLevel);
    }

    public void LoadLevel(int index)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(i == index);
        }
    }

    public void CompleteLevel()
    {
        levels[currentLevel].SetActive(false);
        currentLevel++;

        if (currentLevel < levels.Length)
        {
            LoadLevel(currentLevel);
        }
        else
        {
            Debug.Log("All puzzles complete! You win!");
            winUI.ShowWinPanel();
        }
    }
}
