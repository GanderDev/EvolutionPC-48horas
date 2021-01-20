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

        public float Price, MoneyPerSecond;

    }

}