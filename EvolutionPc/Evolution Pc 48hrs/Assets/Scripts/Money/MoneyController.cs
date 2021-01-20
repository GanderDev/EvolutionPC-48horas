using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EvolutionPC.Money
{
    
    using EvolutionPC.Parts;

    public class MoneyController : MonoBehaviour
    {

        public Text MoneyTxt;
        float Timer;

        private void FixedUpdate()
        {
            
            Timer += Time.deltaTime;

            if(Timer >= 1)
            {

                Timer = 0;

                AddMoney();
                
                MoneyTxt.text = GameController.ShowMoney().ToString();

            }

        }

        void AddMoney()
        {

            float MoneyAdd = TakeMonetPerSecond(GameController.SendSelectedList());

            GameController.AddMoney(MoneyAdd);

        }

        float TakeMonetPerSecond(List<SelectedDataSave> PartLevelList)
        {

            int Part = 0;

            float MoneyAdict = 0;

            foreach(SelectedDataSave SelectedData in PartLevelList)
            {

                foreach(int Level in SelectedData.SelectedLevel)
                {

                MoneyAdict += GameController.PartDataFinder(Part,Level,GameController.GC()._SOBJPartList).MoneyPerSecond;

                }

                Part++;

            }

            return MoneyAdict;

        }

    }

}