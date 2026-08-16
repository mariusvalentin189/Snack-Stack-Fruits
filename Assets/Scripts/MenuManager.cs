using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject resetConfirmPanel;
    [SerializeField] Button resetProgressButton;
    [SerializeField] LevelsManager levelsManager;

    void Start()
    {
        if(PlayerPrefs.HasKey("LevelCompleted1")) //Check if atleas the first level was completed
            resetProgressButton.interactable = true;
        else resetProgressButton.interactable = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)
            {
                SettingsButtons.Instance.Back();
                settingsPanel.SetActive(false);
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Settings()
    {
        settingsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetProgress()
    {
        resetConfirmPanel.SetActive(true);
    }
    public void NoResetProgress()
    {
        resetConfirmPanel.SetActive(false);
    }
    public void ConfirmResetProgress()
    {
        for(int i=1;i<=10;i++)
        {
            PlayerPrefs.DeleteKey("LevelCompleted" + i);
            PlayerPrefs.DeleteKey("LevelScore" + i);
            PlayerPrefs.DeleteKey("LevelStars" + i);
        }
        resetConfirmPanel.SetActive(false);
        resetProgressButton.interactable = false;
        levelsManager.LockAllLevels();
    }
}
