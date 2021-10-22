namespace EvolutionPC.SaveAndLoadGame.GameData
{

    [System.Serializable]
    public class GameDataSave 
    {

        public float Money;
        public string PartSelected;
        public string PartData;

        public GameDataSave( SaveData SD)
        {

            Money = SD._Money;

            PartSelected = SD.SelectedStg;

            PartData = SD.PartDataStorageStg;

        }

    }

}