using UnityEngine;

namespace EvolutionPC.UpGrade
{

    using EvolutionPC.Aviso;
    using EvolutionPC.Money.PC;
    using EvolutionPC.Parts.InGame;

    [System.Serializable]
    public struct Rules
    {

        public int Processor, RamMemory, GraphicCard;

    }

    public class UpGradeSystem : MonoBehaviour
    {

        public Rules[] levelUpGradeRules;

        public bool UpGradeCheck(int PartType, int Level)
        {

            Level += 1;

            switch (PartType)
            {

                case 0:

                    if (Level <= GameController.Instance.IntToPartData(0)[GameController.Instance.IntToPartData(0).Count - 1].Nivel)
                    {

                        if (levelUpGradeRules[Level - 2].Processor == TemporariStorageData.TakePartSelectedLevel(1)
                        && levelUpGradeRules[Level - 2].RamMemory == TemporariStorageData.TakePartSelectedLevel(2)
                        && levelUpGradeRules[Level - 2].GraphicCard == TemporariStorageData.TakePartSelectedLevel(3))
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

                    if (levelUpGradeRules[TemporariStorageData.TakePartSelectedLevel(0) - 1].Processor >= Level)
                    {

                        return true;

                    }

                    GameObject.FindObjectOfType<AvisoController>().CreatAvisoPainel("O nivel de sua Placa Mãe não é alto o suficiente");

                    return false;

                case 2:

                    if (levelUpGradeRules[TemporariStorageData.TakePartSelectedLevel(0) - 1].RamMemory >= Level)
                    {

                        return true;

                    }

                    GameObject.FindObjectOfType<AvisoController>().CreatAvisoPainel("O nivel de sua Placa Mãe não é alto o suficiente");

                    return false;

                case 3:

                    if (levelUpGradeRules[TemporariStorageData.TakePartSelectedLevel(0) - 1].GraphicCard >= Level)
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

            TemporariStorageData.RemoveIntToPartDataStorage(Level, GameController.TellPartType());
            TemporariStorageData.RemoveIntToPartDataStorage(Level, GameController.TellPartType());

            TemporariStorageData.AddIntToPartDataStorage(Level + 1, GameController.TellPartType());

            PCSelectController.UpdateSelected(Level + 1, GameController.TellPartType());

            GameObject.FindObjectOfType<CreatPartInGame>().CreatPart(Level + 1);

        }

    }

}
