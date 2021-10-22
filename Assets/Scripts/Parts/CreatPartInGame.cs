using UnityEngine;

namespace EvolutionPC.Parts.InGame{

    public class CreatPartInGame : MonoBehaviour
    {
    
        public GameObject PartInGamePrefab;
        public Transform FatherGOBJ;

        GameController _GC;

        private void Start()
        {
            
            _GC = GameController.GC();

            CreatAllParts();

        }

        #region  Create

        public void CreatPart(int PartLevel)
        {
            
            int PartType = GameController.TellPartType();

            GameObject Object = Instantiate(PartInGamePrefab, FatherGOBJ);

            Object.GetComponent<PartInGame>().SetData(GameController.PartDataFinder(PartType, PartLevel, _GC._SOBJPartList));

        }

        public void CreatAllParts()
        {

            DestroyAllParts();
            
            int PartType = GameController.TellPartType();

            foreach(int PartLevel in _GC.SendPartList(PartType))
            {

                GameObject Object = Instantiate(PartInGamePrefab, FatherGOBJ);

                Object.GetComponent<PartInGame>().SetData( GameController.PartDataFinder(PartType,PartLevel,_GC._SOBJPartList ));

            }

        }

        #endregion

        #region  Destroy

        public void DestroyAllParts()
        {

            PartInGame[] Childrens = FatherGOBJ.GetComponentsInChildren<PartInGame>();

            foreach(PartInGame Children in Childrens)
            {

                if(Children != FatherGOBJ)
                {

                    Children.AutoDestruct();

                }

            }

        }

        #endregion

    }

}