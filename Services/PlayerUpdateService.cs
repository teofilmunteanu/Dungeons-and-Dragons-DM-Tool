using Deez_Notes_Dm.JsonManagers;

namespace Deez_Notes_Dm.Services
{
    public class PlayerUpdateService
    {
        PlayersJsonManager _playersJsonManager;
        public PlayerUpdateService()
        {
            _playersJsonManager = PlayersJsonManager.Instance;
        }

        public void AddXpToPlayer(int id, int xp)
        {
            if (xp > 0)
            {
                _playersJsonManager.Players[id].XP += xp;

                //while (totalLevel < 20 && this.XP > XPbyLevel[this.totalLevel + 1])
                //{
                //    levelUp();
                //}

                _playersJsonManager.SavePlayers();
            }


        }
    }
}
