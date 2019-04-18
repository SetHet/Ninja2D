using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movimiento : MonoBehaviour
    {
        #region Variables
        bool grounded = false;
        bool inJump = false;
        #endregion

        #region Basic Methods
        private void Update()
        {
            DetectGround();
        }
        #endregion

        #region Ground
        void DetectGround()
        {
            grounded = false;
        }
        #endregion

        #region Movement
        void Movement()
        {

        }

        void Jump()
        {

        }
        #endregion




    }
}