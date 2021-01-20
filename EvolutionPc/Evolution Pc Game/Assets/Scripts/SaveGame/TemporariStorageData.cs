using System.Collections.Generic;

namespace EvolutionPC
{
    public static class TemporariStorageData
    {

        #region SaveVariableInGC

        static float MoneyFloat;

        static List<int> _SelectedLevelParts = new List<int>();

        static List<List<int>> _PartDataStorageList = new List<List<int>>();

        #endregion

        #region Money

        public static float TakeMoney() => MoneyFloat;

        public static float AddMoney(float AddMoneyF) => MoneyFloat += AddMoneyF;

        public static float RemoveMoney(float RemoveMoneyF) => MoneyFloat -= RemoveMoneyF;

        public static void SetMoney(float Money) => MoneyFloat = Money;

        #endregion

        #region PartDataStorage

        public static void AddIntToPartDataStorage(int NewInt, int Index) => _PartDataStorageList[Index].Add(NewInt);

        public static void RemoveIntToPartDataStorage(int RemoveInt, int Index) => _PartDataStorageList[Index].Remove(RemoveInt);

        public static List<int> TakePartDataStorageList(int Index) => _PartDataStorageList[Index];

        public static List<List<int>> TakePartDataStorageList() => _PartDataStorageList;

        public static void SetParDataListList(List<List<int>> _PartListOfList) => _PartDataStorageList = _PartListOfList;

        #endregion

        #region LevelData

        public static int TakePartSelectedLevel(int Index) => _SelectedLevelParts[Index];

        public static List<int> TakePartSelectedLevel() => _SelectedLevelParts; 

        public static void SetPartSelectedLevel(int Level, int Index) { _SelectedLevelParts[Index] = Level; UpdateInfo(); }

        public static void SetPartSelectedLevell(List<int> LevelList) { _SelectedLevelParts = LevelList; UpdateInfo(); }

        static void UpdateInfo() => InfoUpdate.UpdateInfo.UpdateSelectedPartInfo(_SelectedLevelParts);

        #endregion

    }

}

namespace EvolutionPC.InfoUpdate
{

    public static class UpdateInfo
    {
    
        public static void UpdateSelectedPartInfo(List<int> SelectedList) 
        {

            Money.MoneyController.UpdateMoneyPerSecond(SelectedList);
            
        }

    }

}

namespace EvolutionPC.SaveAndLoadGame
{

    public static class SaveManager
    {

        public static void SetVariables(LoadData LoadData)
        {

            TemporariStorageData.SetMoney(LoadData._Money);

            TemporariStorageData.SetParDataListList(LoadData._PartDataStorageList);

            TemporariStorageData.SetPartSelectedLevell(LoadData._SelectedList);

        }

    }

}