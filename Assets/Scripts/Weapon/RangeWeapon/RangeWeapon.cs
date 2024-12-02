using UnityEngine;

namespace Weapon.RangeWeapon
{
    public abstract class RangeWeapon : Weapon
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _range;
        
        private readonly Vector3 _rayPosition = new Vector3(0.5f, 0.5f, 0f);
        
        protected override void Attack()
        {
            if (PlayerInput.AttackInput)
            {
                var ray = _camera.ViewportPointToRay(_rayPosition);

                if (Physics.Raycast(ray, out var hit, _range))
                {
                    if (hit.transform.TryGetComponent(out Enemy.Enemy enemy))
                    {
                        print(enemy.name);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(_rayPosition, _rayPosition * _range, Color.red);
        }
    }
}