using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Combat : MonoBehaviour
    {
        private void Update()
        {
            Attack();
        }

        void Attack()
        {
            if (InputMaster.current.isAtackDown())
            {
                ControlAnimations.current.Call_Attack();
            }
        }
    }
}