using System;
using Control;
using UnityEditor;
using UnityEngine;

namespace Entities
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerControllerBase _controller;
        [SerializeField] public SpriteRenderer _sprite;
        [SerializeField] public PlayerAnimation Animation;
        [SerializeField] public SpriteRenderer _playerIdSprite;

        private int _playerId;

        public int PlayerId
        {
            get { return _playerId; }
            set
            {
                _playerId = value;
            }
        }

        public void LookLeft() { _controller.UpdateViewDirection(new Vector2(-1,0)); }
        public Color Color { set { _sprite.color = value; } }
        

        void Start()
        {
           
        }

        public PlayerControllerBase GetPlayerController()
        {
            return _controller;
        }
    }
}