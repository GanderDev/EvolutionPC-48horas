using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC
{
    
    using EvolutionPC.Store;
    using EvolutionPC.Parts;

    public class GameController : MonoBehaviour
    {

        public ScriptableOBJPartList[] _SOBJPartList;

        static GameController _GC;

        #region SaveVariableInGC

        static float MoneyFloat;

        public List<SelectedDataSave> _SelectedLevelParts = new List<SelectedDataSave>();

        public List<PartDataStorage> _PartDataStorageList = new List<PartDataStorage>();

        #endregion

        enum PartType {MotherBoard, Processor, RamMemory, GraphicCard}

        static PartType _PartType = 0;

        private void Awake() 
        {
        
            GameController[] GC = GameObject.FindObjectsOfType<GameController>(); 

            if(GC.Length > 1)
            {

                Destroy(this.gameObject);

            }

            DontDestroyOnLoad(this.gameObject);

        }
        public static GameController GC()
        {
            
            _GC = (_GC == null)? GameObject.FindObjectOfType<GameController>() : _GC;

            return _GC;
            
        }

        #region PartDataStorageList

        public void SetList(List<PartDataStorage> _PartListOfList) => _PartDataStorageList = _PartListOfList;

        public void AddIntToList(int NewInt, int Index) => _PartDataStorageList[Index].PartListIndex.Add(NewInt);

        public void RemoveIntToList(int RemoveInt, int Index) => _PartDataStorageList[Index].PartListIndex.Remove(RemoveInt);

        public List<int> SendPartList(int Index) => _PartDataStorageList[Index].PartListIndex;

        #endregion

        #region PartFinder

        public static PartData PartDataFinder(int PartType, int PartLevel, ScriptableOBJPartList[] SOBJPartList)
        => SOBJPartList[PartType].PartList[PartLevel - 1];

        #endregion

        #region PartType

        public static void SetPartType(int Partype) => _PartType = (PartType) Partype;

        public static int TellPartType() => (int)_PartType;
        
        public static int TellPartLevel(int Index) => GC()._SelectedLevelParts[Index].SelectedLevel[0];//MUDAR MAIS PARA FRENTE

        public static List<SelectedDataSave> TellPartLevelList() => GC()._SelectedLevelParts;

        public static void SetPartLevel(int Level ,int Index) => GC()._SelectedLevelParts[Index].SelectedLevel[0] = Level;

        #endregion

        #region IntTo

        public static List<PartData> IntToPartData(int Index = -1)
        {

            if(Index < 0)
            {

                Index = TellPartType();

            }

            ScriptableOBJPartList SOBJPart = GC()._SOBJPartList[Index];

            List<PartData> PartDataList = SOBJPart.PartList;

            return PartDataList;

        }
        public static PartDataStorage IntToPartDataStorage(int Index)
        {

            if(Index == 0)
            {

                Index = TellPartType();

            }

            PartDataStorage PartDataStorage = GC()._PartDataStorageList[Index];

            return PartDataStorage;

        }

        public static List<PartDataStorage> IntToPartDataStorage()
        {

            List<PartDataStorage> PartDataStorage = GC()._PartDataStorageList;

            return PartDataStorage;

        }

        #endregion

        #region Money

        public static float ShowMoney() => MoneyFloat;

        public static float AddMoney(float AddMoneyF) => MoneyFloat += AddMoneyF;

        public static float RemoveMoney(float RemoveMoneyF) => MoneyFloat -= RemoveMoneyF;

        #endregion

        #region PcPartSelected

        public static void SetPart(int PartType,int PartLevel)//MUDAR MAIS PARA FRENTE
        {

            GC()._SelectedLevelParts[PartType].SelectedLevel[0] = PartLevel;
            
        }

        public static List<SelectedDataSave> SendSelectedList() => GC()._SelectedLevelParts;//MUDAR MAIS PARA FRENTE

        #endregion

        #region SaveFunctions

        public static void SetVariables(SaveAndLoadGame.LoadData LoadData)
        {

            SetMoney(LoadData._Money);

            SetPartStorageList(LoadData._PartDataStorageList);

            SetSelectedList(LoadData._SelectedList);

        }

        public static void SetMoney(float Money) => MoneyFloat = Money;

        public static void SetPartStorageList(List<PartDataStorage> PartStorageList ) => GC()._PartDataStorageList = PartStorageList;

        public static void SetSelectedList(List<SelectedDataSave> SelectedList ) => GC()._SelectedLevelParts = SelectedList;

        #endregion

    }

}