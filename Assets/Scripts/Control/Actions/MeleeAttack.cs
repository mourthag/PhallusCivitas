using Assets.Scripts.Util;
using Entities;
using Gamelogic;
using UniRx;
using UnityEngine;

namespace Control.Actions
{
    public class MeleeAttack : Action
    {
        [SerializeField] private Collider2D _weaponCollider;

        private void Start()
        { 
            Player.Animation.State.Subscribe(state => _weaponCollider.gameObject.SetActive(state == PlayerAnimationState.Attack));
            var teamIdentifier = _weaponCollider.gameObject.AddComponent<TeamIdentifier>();
            teamIdentifier.TeamId = Player.TeamId();
        }

        public override void Activate(Direction direction)
        {
        }
    }
}