using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC.Parts
{

    [CreateAssetMenu(fileName = "ScriptableOBJPartList", menuName = "Part/ScriptableOBJPartList")]
    public class ScriptableOBJPartList : ScriptableObject
    {
        
        public List<PartData> PartList = new List<PartData>();

    }

}