using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class ControlAnimations : MonoBehaviour
    {
        #region Singleton
        static ControlAnimations _current;
        public static ControlAnimations current { get { return _current; } }
        void Singleton()
        {
            if (_current == null) _current = this;
            else Debug.Log("Hay varios ControlAnimation activos, eso esta mal");
        }
        #endregion

        #region Basic Methods
        private void Awake()
        {
            Singleton();
            animator = GetComponent<Animator>();
        }
        #endregion

        #region Variables
        Animator animator;
        [SerializeField] string Attack = "Attack";
        [SerializeField] string inAir = "inAir";
        #endregion

        #region Methods
        public void Call_Attack()
        {
            animator.SetTrigger(Attack);
        }

        public void Set_InAir(bool value)
        {
            animator.SetBool(inAir, value);
        }
        #endregion
    }
}