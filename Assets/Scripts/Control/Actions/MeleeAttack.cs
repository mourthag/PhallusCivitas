using Assets.Scripts.Util;
using Entities;
using UniRx;
using UnityEngine;

namespace Control.Actions
{
    public class MeleeAttack : Action
    {
        [SerializeField] private Collider2D _weaponCollider;

        private void Awake()
        { 
            PlayerAnimation.State.Subscribe(state => _weaponCollider.gameObject.SetActive(state == PlayerAnimationState.Attack));
        }

        public override void Activate(Direction direction)
        {
            
        }
    }
}