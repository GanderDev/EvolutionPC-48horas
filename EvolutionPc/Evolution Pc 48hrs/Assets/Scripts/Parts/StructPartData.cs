using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC.Parts
{

    [System.Serializable] 
    public struct PartData
    {

        public Sprite PartImageStore, PartImageInGame;

        public string Name;
        
        public int Nivel;
        enum PartType {MotherBoard, Processor, RamMemory, GraphicCard}

        [SerializeField] PartType _PartType;

        public float Price, MoneyPerSecond;

    }

    [System.Serializable] 
    public struct PartDataStorage
    {

        public List<int> PartListIndex; 

    }

    [System.Serializable]

    public struct SelectedDataSave
    {

        public List<int> SelectedLevel;

    }

}