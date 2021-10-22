using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC.Money.PC
{
    
    using EvolutionPC.Parts;
    using EvolutionPC.Store;

    public class PCSelectController
    {

        public StoreController _StoreController;

        public static void UpdateSelected(int Level, int PartType)
        {

            GameController.SetPartLevel(Level, PartType);

        }

    }

}