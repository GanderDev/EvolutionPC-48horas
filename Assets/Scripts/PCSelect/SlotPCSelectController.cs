using UnityEngine;
using UnityEngine.UI;

namespace EvolutionPC.Money.PC
{

    using EvolutionPC.Parts;

    public class SlotPCSelectController : MonoBehaviour, IAutoDestruct
    {



        public Image IconImg, ButtonImg;

        public Text NameTxt, MoneyPerSecondTxt;

        float MoneyPerSecond;

        int Level;

        public int ShowLevel() => Level;

        public void SetData(PartData _PartData, bool Selected = false)
        {

            IconImg.sprite = _PartData.PartImageStore;

            NameTxt.text = _PartData.Name;
            MoneyPerSecondTxt.text = _PartData.Price.ToString();

            MoneyPerSecond = _PartData.MoneyPerSecond;

            Level = _PartData.Nivel;

        }

        public void SetSprite(Sprite ButtonSprite)
        {

            ButtonImg.sprite = ButtonSprite;

        }

        void IAutoDestruct.AutoDestruct()
        {

            Destroy(gameObject);

        }

        public void SelectPart()
        {

            GameController.SetPart(GameController.TellPartType(),Level);

        }
    
    }

}