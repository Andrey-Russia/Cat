using YG;

namespace YG
{
    public partial class SavesYG
    {
        public int coins;
        public int clickLevel;
        public int catLevel;
        public int catCount;
        public int totalCoinsEarned;

        public bool tutorialCompleted;
        public bool firstLaunch = true;
        public bool achievementFirstCoin;
        public bool achievement100Coins;
        public bool achievement1000Coins;
        public bool achievementFirstCat;
        public bool achievement10Cats;
        public bool hasExitedGame;

        public string lastExitTime;
    }
}