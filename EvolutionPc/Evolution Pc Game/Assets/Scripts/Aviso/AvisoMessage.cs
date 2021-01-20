using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EvolutionPC.Aviso
{

    public class AvisoMessage : MonoBehaviour
    {
    
        public Text MessegeTxt;  

        public void SetText(string MessegeStg)
        {

            MessegeTxt.text = MessegeStg;

        }

        public void CloseAviso()
        {

            Destroy(gameObject);

        }

    }

}