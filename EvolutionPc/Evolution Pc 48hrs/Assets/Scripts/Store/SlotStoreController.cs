using UnityEngine;
using UnityEngine.UI;

namespace EvolutionPC.Store
{

    using EvolutionPC.Parts;
    using EvolutionPC.Parts.InGame;

    public class SlotStoreController : MonoBehaviour, IAutoDestruct
    {

        public Image IconImg;

        public Text NameTxt,PriceTxt;

        float Price;

        int Level;

        public void SetData(PartData _PartData)
        {

            IconImg.sprite = _PartData.PartImageStore;

            NameTxt.text = _PartData.Name;
            PriceTxt.text = _PartData.Price.ToString();

            Price = _PartData.Price;

            Level = _PartData.Nivel;
            

        }
        
        void IAutoDestruct.AutoDestruct()
        {

            Destroy(gameObject);

        }

        public void BuyComponent()
        {

            

            if(GameController.ShowMoney() >= Price)
            {

                GameController.RemoveMoney(Price);

                GameController.GC().AddIntToList(Level, GameController.TellPartType());

                GameObject.FindObjectOfType<CreatPartInGame>().CreatPart(Level);

            }

        }
    
    }

}