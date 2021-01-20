namespace EvolutionPC.Money.PC
{

    public class PCSelectController
    {

        public static void UpdateSelected(int Level, int PartType)
        {

            TemporariStorageData.SetPartSelectedLevel(Level, PartType);

        }

    }

}