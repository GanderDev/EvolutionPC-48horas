using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC.ButtonsPartInGame{

    using EvolutionPC.Parts.InGame;
    using EvolutionPC.Store;

    public class ChangePartController : MonoBehaviour
    {
    
        static CreatPartInGame _CreatPartInGame;

        public static void ChangePartInGame(int Index)
        {
            
            if(_CreatPartInGame == null) _CreatPartInGame = GameObject.FindObjectOfType<CreatPartInGame>();

            if(GameController.TellPartType() == Index) return;

            GameController.SetPartType(Index);

            _CreatPartInGame.CreatAllParts();

            GameObject.FindObjectOfType<StoreController>().UpdateStore();

        }

    }

}
