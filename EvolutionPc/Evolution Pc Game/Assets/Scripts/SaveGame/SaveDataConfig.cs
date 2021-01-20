using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC.SaveAndLoadGame
{

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

        public List<List<int>> _PartDataStorageList;

        public List<int> _SelectedList;

    }

    public class SaveDataConfig
    {

        SaveData _SaveData = new SaveData();
        LoadData _LoadData = new LoadData();

        char[] FilterL1 = { ';' }, FilterL2 = { ',' };

        #region Save

        public SaveData Save(float Money, List<int> Selected, List<List<int>> PartDataStorageList)
        {

            _SaveData._Money = Money;

            _SaveData.PartDataStorageStg = PartStorageToString(PartDataStorageList);

            _SaveData.SelectedStg = SelectedListToString(Selected);

            return _SaveData;

        }

        string PartStorageToString(List<List<int>> PartDataStorageList)
        {

            string Result = ";";

            foreach (List<int> PartData in PartDataStorageList)
            {

                Result += ListIntToString(PartData) + ";";

            }

            return Result;

        }

        string SelectedListToString(List<int> Selected)
        {

            string Result = ";";

            Result += ListIntToString(Selected) + ";";

            return Result;

        }

        string ListIntToString(List<int> PartListIndex)
        {

            string Result = "";

            foreach (int PartIndex in PartListIndex
)
            {

                Result += PartIndex + ",";

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

        public List<List<int>> StringToPartStorage(string PartDataStorageStg)
        {

            string[] PartDataFL1 = PartDataStorageStg.
            Split(FilterL1, System.StringSplitOptions.RemoveEmptyEntries);

            List<List<int>> PartDataStorageList = new List<List<int>>();

            foreach (string PartDataIndex in PartDataFL1)
            {

                List<int> IndexSplitedFL2 = StringToIntList(PartDataIndex);

                PartDataStorageList.Add(IndexSplitedFL2);

            }

            return PartDataStorageList;

        }

        public List<int> StringToSelectedData(string SelectDataSring)
        {

            string[] SelectDataFL1 = SelectDataSring.
            Split(FilterL1, System.StringSplitOptions.RemoveEmptyEntries);

            List<int> SelectedDataStorageList = new List<int>();

            foreach (string SelectDataIndex in SelectDataFL1)
            {

                List<int> IndexSplitedFL2 = StringToIntList(SelectDataIndex);

                SelectedDataStorageList = IndexSplitedFL2;

            }

            return SelectedDataStorageList;

        }

        List<int> StringToIntList(string StringToList)
        {

            string[] StringArray = StringToList.
            Split(FilterL2, System.StringSplitOptions.RemoveEmptyEntries);

            List<int> IndexSplitedFL2 = new List<int>();

            foreach (string String in StringArray)
            {

                IndexSplitedFL2.Add(int.Parse(String));

            }

            return IndexSplitedFL2;

        }

        #endregion

    }

}