using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC
{
    
    using EvolutionPC.Store;
    using EvolutionPC.Parts;

    public class GameController : MonoBehaviour
    {

        public static GameController Instance;

        public ScriptableOBJPartList[] _SOBJPartList;

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

            Instance = this;

        }

        #region PartFinder

        public static PartData PartDataFinder(int PartType, int PartLevel, ScriptableOBJPartList[] SOBJPartList)
        => SOBJPartList[PartType].PartList[PartLevel - 1];

        #endregion

        #region PartType

        public static void SetPartType(int Partype) => _PartType = (PartType) Partype;

        public static int TellPartType() => (int)_PartType;

        #endregion

        #region IntTo

        public List<PartData> IntToPartData(int Index = -1)
        {

            if(Index < 0)
            {

                Index = TellPartType();

            }

            ScriptableOBJPartList SOBJPart = _SOBJPartList[Index];

            List<PartData> PartDataList = SOBJPart.PartList;

            return PartDataList;

        }

        #endregion

    }

}