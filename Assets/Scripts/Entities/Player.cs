using System;
using Control;
using Gamelogic;
using UniRx;
using UnityEditor;
using UnityEngine;

namespace Entities
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private PlayerControllerBase _controller;
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private TeamIdentifier _team;
        [SerializeField] private PlayerHealth _health;

        [SerializeField] private int _teamId;
        [SerializeField] private int _playerId = 1;
        [SerializeField] private float _respawnTime = 0.5f;

        private LevelController _levelController;

        private void Awake()
        {
            _team = GetComponent<TeamIdentifier>();
            if (!Team)
            {
                _team = gameObject.AddComponent<TeamIdentifier>();
                _team.TeamId = _teamId;
            }
            _levelController = FindObjectOfType<LevelController>();
        }

        public int TeamId()
        {
            return Team.TeamId;
        }

        public int PlayerId
        {
            get { return _playerId; }
            set
            {
                _playerId = value;
            }
        }

        public SpriteRenderer SpriteRenderer
        {
            get { return _spriteRenderer;}
        }

        public PlayerAnimation Animation
        {
            get{ return _animation;}
        }

        public PlayerControllerBase Controller
        {
            get{ return _controller;}
        }

        public TeamIdentifier Team
        {
            get { return _team;}
        }

        public PlayerHealth Health
        {
            get { return _health;}
        }

        public float RespawnTime
        {
            get { return _respawnTime;}
        }

        public void Die(bool respawn=true)
        {
            Animation.Die();
            _controller.DisableInput();
            _health.SetInvincible(_respawnTime);

            if (respawn)
            {
                Observable.Timer(TimeSpan.FromSeconds(_respawnTime))
                    .Subscribe(_ =>
                    {
                        _levelController.Respawn(_playerId);
                        _controller.EnableInput();
                    });
            }
        }

        public void LookLeft() { Controller.UpdateViewDirection(new Vector2(-1,0)); }
    }
}