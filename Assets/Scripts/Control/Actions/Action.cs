using System;
using UnityEngine;
using Assets.Scripts.Util;
using Entities;
using UniRx;

namespace Control.Actions
{

    public abstract class Action : MonoBehaviour
    {
        [SerializeField] protected ActionType AcType = ActionType.Other;

        [SerializeField] protected float WindupTime = 0;
        [SerializeField] protected float CooldownTime = 1;
        [SerializeField] protected Player Player;

        protected Cooldown Cooldown;
        protected bool IsOnCooldown;


        private void Awake()
        {

            Cooldown = new Cooldown(CooldownTime);
            Cooldown.IsOnCoolDown.Where(cd => !cd).Subscribe(_ => IsOnCooldown = false);
        }

        public virtual void TryToActivate(Direction direction)
        {
            if (Cooldown.IsOnCoolDown.Value) return;

            Cooldown.Start();
            IsOnCooldown = true;

            switch (AcType)
            {
                case ActionType.Attack:
                    Player.Animation.Attack();
                    break;
                case ActionType.Skill:
                    Player.Animation.UseSkill();
                    break;
                case ActionType.Other:
                    break;
            }

            Observable.Timer(TimeSpan.FromSeconds(WindupTime)).Subscribe(_ => Activate(direction));
        }

        public abstract void Activate(Direction direction);

        public enum ActionType
        {
            Skill,
            Attack,
            Other
        }
    }
}