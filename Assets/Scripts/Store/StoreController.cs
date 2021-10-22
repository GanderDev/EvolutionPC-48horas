using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC.Store
{
    
    using EvolutionPC.Parts;
    using EvolutionPC.Money.PC;

    public class StoreController : MonoBehaviour
    {

        public GameObject StoreSlotPrefab, StorePage, Container;

        bool Open = false;

        public void OpenCloseStore()
        {

            Open = !Open;

            if(Open)
            {

                StorePage.SetActive(true);

                CreatSlots(GameController.IntToPartData());

            }
            else
            {

                DestroySlots();
                
                StorePage.SetActive(false);

            }

        }

        public void UpdateStore()
        {

            if(Open)
            {
                
                DestroySlots();
                CreatSlots(GameController.IntToPartData());

            }

        }

        public void CreatSlots(List<PartData> PartDataList)
        {

            int Level = GameController.TellPartLevel(GameController.TellPartType());

            foreach(PartData _PartData in PartDataList)
            {

                if(_PartData.Nivel == 1 ||  Level - _PartData.Nivel  > 1)
                {

                GameObject StoreSlot = Instantiate(StoreSlotPrefab, Container.GetComponent<Transform>());

                StoreSlot.GetComponent<SlotStoreController>().SetData(_PartData);

                }

            }

        }

        public void DestroySlots()
        {
            
            IAutoDestruct[] Childrens = Container.GetComponentsInChildren<IAutoDestruct>();

            foreach(IAutoDestruct Children in Childrens)
            {

                Children.AutoDestruct();

            }

        }

    }

}