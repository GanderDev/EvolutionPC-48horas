using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EvolutionPC.Money
{
    public class MoneyController : MonoBehaviour
    {

        public Text MoneyTxt;

        static float MoneyUpdated = 0;

        float Timer;

        private void Start()
        {

            UpdateMoneyPerSecond(TemporariStorageData.TakePartSelectedLevel());

        }

        private void FixedUpdate()
        {

            Timer += Time.deltaTime;

            if (Timer >= 1)
            {

                Timer = 0;

                AddMoney();

            }

        }

        void AddMoney()
        {

            TemporariStorageData.AddMoney(MoneyUpdated);

            MoneyTxt.text = TemporariStorageData.TakeMoney().ToString();

        }

        public static void UpdateMoneyPerSecond(List<int> PartLevelList)
        {

            float MoneyAdict = 0;

            for (int Part = 0; PartLevelList.Count - 1 >= Part; Part++)
            {
                
                MoneyAdict += GameController.PartDataFinder(Part, PartLevelList[Part], GameController.Instance._SOBJPartList).MoneyPerSecond;

            }

            MoneyUpdated = MoneyAdict;

        }

    }

}