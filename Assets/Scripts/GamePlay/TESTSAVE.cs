using YG;
using UnityEngine;

public class TestSave : MonoBehaviour
{
    public void SaveGame()
    {
        YG2.SaveProgress();

        Debug.Log("GAME SAVED");
    }
}