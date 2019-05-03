using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class InputMaster : MonoBehaviour
    {
        #region singleton
        static InputMaster _current;
        public static InputMaster current { get { return _current; } }
        void Singleton()
        {
            if (_current == null) _current = this;
            else Destroy(gameObject);
        }
        #endregion

        #region Basic Methods
        private void Awake()
        {
            Singleton();
        }
        #endregion

        #region Variables
        public string MoveHorizontal = "Horizontal";
        public string MoveVertical = "Vertical";
        public string Jump = "Jump";
        public KeyCode Atack = KeyCode.RightShift;
        #endregion

        #region Methods
        public Vector2 Mov()
        {
            if (AndroidControl.instance != null)
            {
                return AndroidControl.instance.stickLeft.GetAxis();
            }
            else
            {
                return new Vector2(Input.GetAxis(MoveHorizontal), Input.GetAxis(MoveVertical));
            }
        }
        public bool isJump()
        {
            if (AndroidControl.instance != null)
            {
                return AndroidControl.instance.jump.IsDown();
            }
            else
            {
                return Input.GetButton(Jump);
            }
        }
        public bool isAtackDown()
        {
            if (AndroidControl.instance != null)
            {
                return AndroidControl.instance.attack.IsDown();
            }
            else
            {
                return Input.GetKeyDown(Atack);
            }
        }
        #endregion
    }
}