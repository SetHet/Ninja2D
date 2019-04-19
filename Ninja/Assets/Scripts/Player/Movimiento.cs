using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movimiento : MonoBehaviour
    {
        #region Variables

        BoxCollider2D coll;
        Rigidbody2D rigid;
        RaycastHit2D hit;
        bool grounded = false;
        bool inJump = false;
        [SerializeField] float distance_detect = 0.01f;
        [SerializeField]LayerMask layerGround = -1;
        [SerializeField] float velocidad_walk = 2;
        [SerializeField] float forceJump = 5;
        #endregion

        #region Basic Methods
        private void Start()
        {
            coll = GetComponent<BoxCollider2D>();
            rigid = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            DetectGround();
            Jump();
            Movement();
        }
        #endregion

        #region Ground
        void DetectGround()
        {
            grounded = false;

            Vector2 Cast_Start = transform.position + (Vector3)coll.offset;
            Vector2 size = coll.size - Vector2.up * distance_detect * 2 - Vector2.right * distance_detect;
            hit = Physics2D.BoxCast(Cast_Start, size, 0f, Vector2.down, distance_detect*2, layerGround);
            if (hit.collider == null) return;
            
            grounded = true;
        }
        #endregion

        #region Movement
        void Movement()
        {
            if (!grounded || inJump) return;
            Vector2 mov = InputMaster.current.Mov().normalized;
            Vector2 derecha = Vector2.Perpendicular(hit.normal);
            if (derecha.x < 0) derecha = -derecha;
            rigid.velocity = derecha * mov.x * velocidad_walk;
        }

        void Jump()
        {
            if (inJump && InputMaster.current.isJump()) return;
            else inJump = false;
            if (!InputMaster.current.isJump()) return;
            if (!grounded) return;
            Vector2 mov = InputMaster.current.Mov().normalized;
            if (mov == Vector2.zero)
                rigid.AddForce(Vector2.up * forceJump * rigid.mass, ForceMode2D.Impulse);
            else rigid.AddForce(mov * forceJump * rigid.mass, ForceMode2D.Impulse);
            grounded = false;
            inJump = true;
        }
        #endregion




    }
}