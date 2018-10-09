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
        [SerializeField] private int _teamId;
        [SerializeField] private TeamIdentifier _team;
        [SerializeField] private PlayerHealth _health;

        [SerializeField] private int _playerId = 1;


        private void Awake()
        {
            _team = GetComponent<TeamIdentifier>();
            if (!Team)
            {
                _team = gameObject.AddComponent<TeamIdentifier>();
                _team.TeamId = _teamId;
            }
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

        public void Die(bool respawn=true)
        {
            Animation.Die();

            if (respawn)
            {
            }
        }

        public void LookLeft() { Controller.UpdateViewDirection(new Vector2(-1,0)); }
    }
}