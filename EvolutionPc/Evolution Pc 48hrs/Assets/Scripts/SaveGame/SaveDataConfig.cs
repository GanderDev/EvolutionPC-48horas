using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC.SaveAndLoadGame
{

    using EvolutionPC.Parts;
    using EvolutionPC.SaveAndLoadGame.GameData;
    
    [System.Serializable]
    public struct SaveData
    {
    
        public float _Money;

        public string SelectedStg, PartDataStorageStg;

    }

    [System.Serializable]
    public struct LoadData
    {

        public float _Money;

        public List<PartDataStorage> _PartDataStorageList;

        public List<SelectedDataSave> _SelectedList;
        
    }

    [CreateAssetMenu(fileName = "SaveDataConfig", menuName = "Save/SaveDataConfig")]
    public class SaveDataConfig : ScriptableObject
    {  

        [SerializeField] SaveData _SaveData = new SaveData();
        [SerializeField] LoadData _LoadData = new LoadData();

        char[] FilterL1 = {';'}, FilterL2 = {','};

        #region Save

        public SaveData Save(float Money, List<SelectedDataSave> Selected, List<PartDataStorage> PartDataStorageList)
        {

            _SaveData._Money = Money;

            _SaveData.PartDataStorageStg = PartStorageToString(PartDataStorageList);

            _SaveData.SelectedStg = SelectedListToString(Selected);

            return _SaveData;

        }

        string PartStorageToString(List<PartDataStorage> PartDataStorageList)
        {

            string Result = ";";

            foreach(PartDataStorage PartData in PartDataStorageList)
            {
                
                Result += ListIntToString(PartData.PartListIndex) + ";";

            }

            return Result;

        }

        string SelectedListToString(List<SelectedDataSave> Selected)
        {

            string Result = ";";

            foreach(SelectedDataSave SelectedData in Selected)
            {
                
                Result += ListIntToString(SelectedData.SelectedLevel) + ";";

            }

            return Result;

        }

        string ListIntToString(List<int> PartListIndex)
        {

            string Result = "";

            foreach (int PartIndex in PartListIndex
)
            {

                Result +=  PartIndex + ",";
                
            }

            return Result;

        }

        #endregion

        #region  Load

        public LoadData Load(GameDataSave GDS)
        {

            _LoadData._Money = GDS.Money;

            _LoadData._PartDataStorageList = StringToPartStorage(GDS.PartData);

            _LoadData._SelectedList = StringToSelectedData(GDS.PartSelected);

            return _LoadData;

        }

        public List<PartDataStorage> StringToPartStorage(string PartDataStorageStg)
        {

            string[] PartDataFL1 = PartDataStorageStg.
            Split(FilterL1,System.StringSplitOptions.RemoveEmptyEntries);

            List<PartDataStorage> PartDataStorageList = new List<PartDataStorage>();

            foreach(string PartDataIndex in PartDataFL1)
            {

                List<int> IndexSplitedFL2 = new List<int>();
                IndexSplitedFL2 = StringToIntList(PartDataIndex);

                PartDataStorage NewPartData = new PartDataStorage();

                NewPartData.PartListIndex = IndexSplitedFL2;
                
                PartDataStorageList.Add(NewPartData);

            }

            return PartDataStorageList;

        }

        public List<SelectedDataSave> StringToSelectedData(string SelectDataSring)
        {

            string[] SelectDataFL1 = SelectDataSring.
            Split(FilterL1,System.StringSplitOptions.RemoveEmptyEntries);

            List<SelectedDataSave> SelectedDataStorageList = new List<SelectedDataSave>();

            foreach(string SelectDataIndex in SelectDataFL1)
            {

                List<int> IndexSplitedFL2 = new List<int>();
                IndexSplitedFL2 = StringToIntList(SelectDataIndex);

                SelectedDataSave NewPartData = new SelectedDataSave();

                NewPartData.SelectedLevel = IndexSplitedFL2;
                
                SelectedDataStorageList.Add(NewPartData);

            }

            return SelectedDataStorageList;

        }

        List<int> StringToIntList(string StringToList)
        {

            string[] StringArray = StringToList.
            Split(FilterL2,System.StringSplitOptions.RemoveEmptyEntries);

            List<int> IndexSplitedFL2 = new List<int>();

            foreach(string String in StringArray)
            {

                IndexSplitedFL2.Add(int.Parse(String));

            }

            return IndexSplitedFL2;

        }

        #endregion

    }

}