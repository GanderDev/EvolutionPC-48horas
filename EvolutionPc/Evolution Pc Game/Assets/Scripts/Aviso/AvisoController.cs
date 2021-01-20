using UnityEngine;

namespace EvolutionPC.Aviso
{

    public class AvisoController : MonoBehaviour
    {
    
        public GameObject PrefabAviso;

        public void CreatAvisoPainel(string Messege)
        {

            GameObject Aviso = Instantiate(PrefabAviso,GameObject.Find("Canvas").transform);

            Aviso.GetComponent<AvisoMessage>().SetText(Messege);

        }

    }

}