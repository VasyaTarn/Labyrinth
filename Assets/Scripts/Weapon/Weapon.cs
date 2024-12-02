using Player;
using UnityEngine;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected PlayerInput PlayerInput;
        [SerializeField] protected float Damage;

        protected abstract void Attack();
    }
}
