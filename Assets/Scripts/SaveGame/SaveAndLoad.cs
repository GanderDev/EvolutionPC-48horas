using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EvolutionPC.SaveAndLoadGame
{

    using EvolutionPC.SaveAndLoadGame.GameData;

    public static class SaveAndLoad
    {
    
        static string FolderPath = "";

        public static void SaveGame()
        {

            BinaryFormatter _BF = new BinaryFormatter();
            
            FolderPath = Application.persistentDataPath + "/SaveFolder";

            if(!Directory.Exists(FolderPath))
            {

                Directory.CreateDirectory(FolderPath);

            }

            FileStream FL = new FileStream(FolderPath + "/Save.save", FileMode.OpenOrCreate);

            SaveDataConfig SDC = new SaveDataConfig();

            GameDataSave GDS = new GameDataSave(SDC.Save(GameController.ShowMoney(), GameController.TellPartLevelList(), GameController.IntToPartDataStorage()));

            _BF.Serialize(FL, GDS);
            FL.Close();

        }

        public static LoadData LoadGame()
        {

            BinaryFormatter BF = new BinaryFormatter();

            FolderPath = Application.persistentDataPath + "/SaveFolder";

            if(!Directory.Exists(FolderPath) || !File.Exists(FolderPath + "/Save.save"))
            {
                
                SaveGame();Debug.Log("ou");
                
            }

            FileStream FL = new FileStream(FolderPath + "/Save.save",FileMode.Open);

            SaveDataConfig SDC = new SaveDataConfig();

            GameDataSave GDS = BF.Deserialize(FL) as GameDataSave ;

            FL.Close();

            return SDC.Load(GDS);

        }

    }

}
