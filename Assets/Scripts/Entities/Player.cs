using System;
using Control;
using Gamelogic;
using UnityEditor;
using UnityEngine;

namespace Entities
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerControllerBase _controller;
        [SerializeField] private int _teamId;
        [SerializeField] private TeamIdentifier _team;
        [SerializeField] private PlayerHealth _health;

        [SerializeField] private int _playerId = 1;


        private void Start()
        {
            _health = gameObject.AddComponent<PlayerHealth>();
            _team = GetComponent<TeamIdentifier>();
            if (!_team)
            {
                _team = gameObject.AddComponent<TeamIdentifier>();
            }
        }

        public int GetTeamId()
        {
            return _team.GetTeamId();
        }

        public int PlayerId
        {
            get { return _playerId; }
            set
            {
                _playerId = value;
            }
        }

        public void LookLeft() { _controller.UpdateViewDirection(new Vector2(-1,0)); }
    }
}