using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EvolutionPC.Mouse{

    public class Mouse : MonoBehaviour
    {

        [SerializeField] public LayerMask FilterLayer;

        void Update()
        {
        
            if(Input.GetMouseButton(0))RayMouse(0);
            if(Input.GetMouseButtonUp(0))RayMouse(1);

        }

        void RayMouse(int MouseButton)
        {

            Vector2 MousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var Raycast2D  = Physics2D.Raycast(MousePosi,Vector2.down,0.1f,FilterLayer);

            if(Raycast2D.collider != null)
            {

                IMouse _IMouse = Raycast2D.collider.GetComponent<IMouse>();

                switch(MouseButton)
                {

                    case 0:

                        _IMouse.HoldPart();

                    break;

                    case 1:

                        _IMouse.DropCheck();

                    break;

                }

            }

        }

    }

}
