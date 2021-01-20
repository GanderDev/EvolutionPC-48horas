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

            if (!Directory.Exists(FolderPath) || !File.Exists(FolderPath + "/Save.save"))
            {

                Directory.CreateDirectory(FolderPath);

                SetTempData();

                FileStream FL = new FileStream(FolderPath + "/Save.save", FileMode.OpenOrCreate);

                SaveDataConfig SDC = new SaveDataConfig();

                GameDataSave GDS = new GameDataSave(SDC.Save(TemporariStorageData.TakeMoney(), TemporariStorageData.TakePartSelectedLevel(), TemporariStorageData.TakePartDataStorageList()));

                _BF.Serialize(FL, GDS);
                FL.Close();

            }
            else
            {

                FileStream FL = new FileStream(FolderPath + "/Save.save", FileMode.OpenOrCreate);

                SaveDataConfig SDC = new SaveDataConfig();

                GameDataSave GDS = new GameDataSave(SDC.Save(TemporariStorageData.TakeMoney(), TemporariStorageData.TakePartSelectedLevel(), TemporariStorageData.TakePartDataStorageList()));

                _BF.Serialize(FL, GDS);
                FL.Close();

            }

        }

        public static void SetTempData() 
        {

            LoadData LD = new LoadData();

            LD._Money = 0;

            List<int> Level1 = new List<int>();

            Level1.Add(1);

            LD._PartDataStorageList = new List<List<int>>();
            LD._PartDataStorageList.Add(Level1);
            LD._PartDataStorageList.Add(Level1);
            LD._PartDataStorageList.Add(Level1);
            LD._PartDataStorageList.Add(Level1);

            LD._SelectedList = new List<int>();
            LD._SelectedList.Add(1);
            LD._SelectedList.Add(1);
            LD._SelectedList.Add(1);
            LD._SelectedList.Add(1);

            SaveManager.SetVariables(LD);
        
        }

        public static LoadData LoadGame()
        {

            BinaryFormatter BF = new BinaryFormatter();

            FolderPath = Application.persistentDataPath + "/SaveFolder";

            if(!Directory.Exists(FolderPath) || !File.Exists(FolderPath + "/Save.save"))
            {
                
                SaveGame();
                
            }

            FileStream FL = new FileStream(FolderPath + "/Save.save",FileMode.Open);

            SaveDataConfig SDC = new SaveDataConfig();

            GameDataSave GDS = BF.Deserialize(FL) as GameDataSave ;

            FL.Close();

            return SDC.Load(GDS);

        }

    }

}
