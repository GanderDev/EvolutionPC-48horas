using UnityEngine;

namespace EvolutionPC.Parts.InGame
{

    using EvolutionPC.Mouse;
    using EvolutionPC.UpGrade;

    public class PartInGame : MonoBehaviour, IMouse
    {

        #region  StatusVariable

        [SerializeField] LayerMask _LayerMask;

        SpriteRenderer _SpriteRenderer;

        BoxCollider2D _BoxCollider2D;

        [HideInInspector]
        public int Level;

        #endregion

        #region  MovimentVariable
        Rigidbody2D RB2D;

        public float MaxForce, BreakForce;

        public float velocityLimitBreakForce;

        public float TimeBtwJump = 0.3f;

        float Timer;

        #endregion

        private void Awake()
        {

            _SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();

            RB2D = gameObject.GetComponent<Rigidbody2D>();

        }
        
        public void SetData(PartData _PartData)
        {

            _SpriteRenderer.sprite = _PartData.PartImageInGame;

            _BoxCollider2D.size = _PartData.PartImageInGame.bounds.size;

            Level = _PartData.Nivel;

        }

        public void AutoDestruct()
        {

            Destroy(gameObject);

        }

        private void FixedUpdate()
        {
        
            Timer += Time.deltaTime;

            if(Timer >= TimeBtwJump){

                Timer = 0;

                RB2D.velocity = new Vector2(0,0);

                PartMovement();

            }

            

            if(RB2D.velocity.magnitude != 0)
            {

                int SideX = (RB2D.velocity.x > 0) ? 1 : -1;
                int SideY = (RB2D.velocity.y > 0) ? 1 : -1;

                float PositiveVelocityX = SideX * RB2D.velocity.x;
                float PositiveVelocityY = SideY * RB2D.velocity.y;

                RB2D.velocity = new Vector2(SideX * (PositiveVelocityX - (BreakForce * Time.deltaTime)),
                                            SideY * (PositiveVelocityY - (BreakForce * Time.deltaTime)));

                if(RB2D.velocity.magnitude <= velocityLimitBreakForce)
                {

                    RB2D.velocity = new Vector2(0,0);

                }

            }

        }

        void PartMovement()
        {   

            int XSide = Random.Range(-1, 1);
            int YSide = Random.Range(-1, 1);

            float X = Random.Range(0.0f, 1.0f);
            float Y = X - 1;

            X *= XSide; Y *= YSide;

            Vector2 XY = new Vector2(X * MaxForce,Y * MaxForce);

            RB2D.AddForce(XY);

        }

        void IMouse.HoldPart()
        {
        
            Vector2 mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3( mousePosi.x, mousePosi.y,85);

        }

        void IMouse.DropCheck()
        {

            var Raycast2D = Physics2D.RaycastAll(transform.position,Vector2.down,0.1f, _LayerMask);

            foreach(RaycastHit2D Raycast in Raycast2D)
            {

                if(Raycast.rigidbody != RB2D)
                {

                    if(Raycast.collider.GetComponent<PartInGame>().Level == Level)
                    {

                        UpGrade(Raycast);

                        return;

                    }

                }

            }

        }

        void UpGrade(RaycastHit2D PartInGameToUpGrade)
        {

            UpGradeSystem _UpGradeSystem = GameObject.FindObjectOfType<UpGradeSystem>();

            if(_UpGradeSystem.UpGradeCheck(GameController.TellPartType(),Level))
            {

                _UpGradeSystem.UpGradeSpawn(Level);

                Destroy(PartInGameToUpGrade.collider.gameObject);
                Destroy(gameObject);

            }

        }

    }

}