using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC.UpGrade
{

    using EvolutionPC.Parts.InGame;
    using EvolutionPC.Money.PC;
    using EvolutionPC.Aviso;

    [System.Serializable]
    public struct Rules
    {

        public int Processor,RamMemory,GraphicCard;

    }

    public class UpGradeSystem : MonoBehaviour
    {

        public Rules[] levelUpGradeRules;

        public bool UpGradeCheck(int PartType, int Level)
        {

            Level += 1;

            switch(PartType)
            {

                case 0:

                    if(Level <= GameController.IntToPartData(0)[GameController.IntToPartData(0).Count - 1].Nivel)
                    {

                        if(levelUpGradeRules[Level - 2].Processor == GameController.TellPartLevel(1)
                        && levelUpGradeRules[Level - 2].RamMemory == GameController.TellPartLevel(2)
                        && levelUpGradeRules[Level - 2].GraphicCard == GameController.TellPartLevel(3))
                        {

                            return true;

                        }

                        GameObject.FindObjectOfType<AvisoController>().CreatAvisoPainel("Você precisa aumentar o nivel das outras peças");

                    }
                    else
                    {

                    GameObject.FindObjectOfType<AvisoController>().CreatAvisoPainel("Você alcançou o nivel maximo =)");

                    }
                    return false;
                    

                case 1:

                    if(levelUpGradeRules[GameController.SendSelectedList()[0].SelectedLevel[0] - 1].Processor >= Level)
                    {
                        
                        return true;

                    }

                    GameObject.FindObjectOfType<AvisoController>().CreatAvisoPainel("O nivel de sua Placa Mãe não é alto o suficiente");

                    return false;

                case 2:

                    if(levelUpGradeRules[GameController.SendSelectedList()[0].SelectedLevel[0] - 1].RamMemory >= Level)
                    {
                        
                        return true;

                    }

                    GameObject.FindObjectOfType<AvisoController>().CreatAvisoPainel("O nivel de sua Placa Mãe não é alto o suficiente");

                    return false;

                case 3:

                    if(levelUpGradeRules[GameController.SendSelectedList()[0].SelectedLevel[0] - 1].GraphicCard >= Level)
                    {
                        
                        return true;

                    }

                    GameObject.FindObjectOfType<AvisoController>().CreatAvisoPainel("O nivel de sua placa mãe não é alto o suficiente");

                    return false;

                default:

                return false;

            }

        }

        public void UpGradeSpawn(int Level)
        {

            GameController.GC().RemoveIntToList(Level,GameController.TellPartType());
            GameController.GC().RemoveIntToList(Level,GameController.TellPartType());

            GameController.GC().AddIntToList(Level + 1, GameController.TellPartType());

            PCSelectController.UpdateSelected(Level + 1, GameController.TellPartType());

            GameObject.FindObjectOfType<CreatPartInGame>().CreatPart(Level + 1);

        }
    
    }

}
