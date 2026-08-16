using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] GameObject uiElements;
    [SerializeField] GameObject lockedIcon;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Image[] starsImages;
    [SerializeField] Sprite starSprite;
    [SerializeField] Sprite emptyStarSprite;
    public void UnlockLevel(int score, int starsCount)
    {
        uiElements.SetActive(true);
        scoreText.text = score.ToString();
        lockedIcon.SetActive(false);
        GetComponent<Button>().interactable = true;
        if (score == 0) return;

        for (int i = 0; i < starsCount; i++)
        {
            starsImages[i].sprite = starSprite;
        }
    }
    public void LockLevel()
    {
        scoreText.text = "0";
        lockedIcon.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            starsImages[i].sprite = emptyStarSprite;
        }
        uiElements.SetActive(false);
        GetComponent<Button>().interactable = false;
    }
    public void ResetLevelStatus()
    {
        uiElements.SetActive(true);
        scoreText.text = "0";
        lockedIcon.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            starsImages[i].sprite = emptyStarSprite;
        }
        GetComponent<Button>().interactable = true;
    }
}
