using UnityEngine;

namespace EvolutionPC.Money.PC
{

    public class SlotCheckSelected : MonoBehaviour
    {
    
        public Sprite Selected, Select;

        public void CheckAllSlots(GameObject FatherSlot)
        {

            SlotPCSelectController[] _ChildrenPCSelects = FatherSlot.GetComponentsInChildren<SlotPCSelectController>();

            foreach(int Level in GameController.GC()._SelectedLevelParts[GameController.TellPartType()].SelectedLevel)
            {

                foreach(SlotPCSelectController _ChildrenPcSelect in _ChildrenPCSelects)
                {

                    if(_ChildrenPcSelect.ShowLevel() == Level)
                    {

                        _ChildrenPcSelect.SetSprite(Selected);

                    }

                }
            
            }

        }

    }

}