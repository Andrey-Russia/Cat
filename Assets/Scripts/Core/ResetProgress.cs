using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class ResetProgressButton : MonoBehaviour
{
    public void ResetProgress()
    {
        YG2.saves.coins = 40;

        YG2.saves.clickLevel = 0;

        YG2.saves.catLevel = 0;
        YG2.saves.catCount = 0;

        YG2.saves.totalCoinsEarned = 0;

        YG2.saves.achievementFirstCoin = false;
        YG2.saves.achievement100Coins = false;
        YG2.saves.achievement1000Coins = false;
        YG2.saves.achievementFirstCat = false;
        YG2.saves.achievement10Cats = false;
        YG2.saves.hasExitedGame = false;
        YG2.saves.tutorialCompleted = false;

        YG2.saves.tutorialCompleted = false;

        YG2.saves.firstLaunch = true;

        YG2.saves.lastExitTime =
            System.DateTime.UtcNow.ToString();

        YG2.SaveProgress();

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }
}