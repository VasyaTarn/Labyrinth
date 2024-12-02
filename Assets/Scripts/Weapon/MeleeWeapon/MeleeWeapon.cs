using UnityEngine;

namespace Weapon.MeleeWeapon
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] private float _attackRadius;
        
        protected override void Attack()
        {
            if (PlayerInput.AttackInput)
            {
                var colliders = Physics.OverlapSphere(transform.position, _attackRadius);

                foreach (var collider in colliders)
                {
                    if (collider.TryGetComponent(out Enemy.Enemy enemy))
                    {
                        print(enemy.name);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);
        }
    }
}