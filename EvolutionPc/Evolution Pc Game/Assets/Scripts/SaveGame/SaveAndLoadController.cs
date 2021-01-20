using UnityEngine;

namespace EvolutionPC.SaveAndLoadGame
{

    public class SaveAndLoadController : MonoBehaviour
    {

        private void Awake()
        {

            LoadData _LoadData = SaveAndLoad.LoadGame();
            SaveManager.SetVariables(_LoadData);

            ButtonsPartInGame.ChangePartController.ChangePartInGame(0);

        }

        public void SaveGame() => SaveAndLoad.SaveGame();

    }

}