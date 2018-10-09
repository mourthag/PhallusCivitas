

using Entities;
using Gamelogic;
using UnityEngine;

namespace Control.Actions
{
    public class BlaneSpecial :  Action
    {
        [SerializeField] private GameObject _projectilePrefab;

        public override void TryToActivate(Direction direction)
        {
            if (IsOnCooldown) return;

            base.TryToActivate(direction);
            Player.Controller.DisableInput();
            Player.Animation.UseSkill();
        }

        public override void Activate(Direction direction)
        {
            ShootProjectile(direction);
        }

        public void ShootProjectile(Direction direction)
        {
            Player.Controller.EnableInput();

            Vector2 projectileSpeed;
            Quaternion rotation = Quaternion.identity;

            switch (direction)
            {
                case Direction.RIGHT:
                    projectileSpeed = Vector2.right;
                    rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case Direction.LEFT:
                    projectileSpeed = Vector2.left;

                    break;
                case Direction.TOP:
                    projectileSpeed = Vector2.up;
                    rotation = Quaternion.Euler(0,0,90);
                    break;
                default:
                    projectileSpeed = Vector2.right;
                    break;
                 
            }

            var projectilGameObject  = Instantiate(_projectilePrefab, transform.position, rotation);
            var projectile = projectilGameObject.GetComponent<Projectile>();
            projectile.SetSpeed(150 * projectileSpeed);

            var teamId = projectilGameObject.AddComponent<TeamIdentifier>();
            teamId.TeamId = Player.TeamId();
        }
    }
}
