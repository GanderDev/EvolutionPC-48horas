using UnityEngine;

namespace EvolutionPC.SaveAndLoadGame
{

    public class SaveAndLoadController : MonoBehaviour
    {
    
        private void Start()
        {

            LoadData _LoadData = SaveAndLoad.LoadGame();
            GameController.SetVariables(_LoadData);

            print(_LoadData._Money);

            ButtonsPartInGame.ChangePartController.ChangePartInGame(0);

        }

        public void SaveGame() => SaveAndLoad.SaveGame();

    }

}