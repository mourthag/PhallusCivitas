using System;
using Control;
using UnityEditor;
using UnityEngine;

namespace Entities
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerControllerBase _controller;

        [SerializeField] private int _playerId = 1;

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