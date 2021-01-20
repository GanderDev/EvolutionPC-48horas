using System.Collections.Generic;
using UnityEngine;
/*
namespace EvolutionPC.SaveAndLoadGame
{

    using EvolutionPC.Parts;

    public static class TemporariStorage 
    {
    
        #region SaveVariableInGC

        static float MoneyFloat;

        static List<int> _SelectedLevelParts = new List<int>();

        static List<PartDataStorage> _PartDataStorageList = new List<PartDataStorage>();

        #endregion

        #region Money

        public static float TakeMoney() => MoneyFloat;

        public static float AddMoney(float AddMoneyF) => MoneyFloat += AddMoneyF;

        public static float RemoveMoney(float RemoveMoneyF) => MoneyFloat -= RemoveMoneyF;

        #endregion

        #region PartDataStorage

        public static void SetList(List<PartDataStorage> _PartListOfList) => _PartDataStorageList = _PartListOfList;

        public static void AddIntToPartDataStorage(int NewInt, int Index) => _PartDataStorageList[Index].PartListIndex.Add(NewInt);

        public static void RemoveIntToPartDataStorage(int RemoveInt, int Index) => _PartDataStorageList[Index].PartListIndex.Remove(RemoveInt);

        public static List<int> TakePartDataStorageList(int Index) => _PartDataStorageList[Index].PartListIndex;

        public static List<PartDataStorage> TakePartDataStorageList() => _PartDataStorageList;

        #endregion

        #region LevelData

        public static int TakePartLevel(int Index) => _SelectedLevelParts[Index];

        public static List<int> TakePartLevel() => _SelectedLevelParts;

        public static void SetPartLevel(int Level, int Index) => _SelectedLevelParts[Index] = Level;

        public static void SetPartLevel(List<int> LevelList, int Index) => _SelectedLevelParts = LevelList;

        #endregion

    }

}*/