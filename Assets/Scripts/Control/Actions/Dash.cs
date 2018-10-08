using System;
using Assets.Scripts.Util;
//using Entities;
using UnityEngine;
using UniRx;

namespace Control.Actions
{
    public class Dash : Action
    {
        //[SerializeField] private Player _player;
        [SerializeField] private float _dashRange = 3;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private float _dashTimeInSeconds = 0.1F;
        [SerializeField] private PlayerControllerBase _controller;
        //[SerializeField] private PlayerLifeSystem _lifeSystem;
        

        private bool OnCooldown
        {
            set { }//_player._sprite.color = value ? new Color(0.8F, 0.8F, 0.8F) : Color.white; }
        }

        public override void TryToActivate(Direction direction)
        {
            if (IsOnCooldown) return;

            base.TryToActivate(direction);

            _controller.ArrestMovement();
        }

        public override void Activate(Direction direction)
        {
            MovePlayer(direction);
        }

        private void MovePlayer(Direction direction)
        {
            Visible = false;
            //TODO Reimport Lifesystem
            //_lifeSystem.SetInvincible(_dashTimeInSeconds);

            Observable.Timer(TimeSpan.FromSeconds(_dashTimeInSeconds)).Subscribe(_ =>
            {
                Visible = true;
            });
            switch (direction)
            {
                case Direction.LEFT:
                    _controller.Controller.Move(new Vector2(-_dashRange, 0));
                    break;
                case Direction.RIGHT:
                    _controller.Controller.Move(new Vector2(_dashRange, 0));
                    break;
                case Direction.TOP:
                    break;
                case Direction.DOWN:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction", direction, null);
            }
        }

        private bool Visible
        {
            set
            {
                //TODO Sound
                //if(!value)
                //    SfxSound.SfxSoundInstance.PlayClip(ClipIdentifier.LokiSkillDisappear);
                _sprite.enabled = value;
                _controller.enabled = value;
            }
        }
    }
}