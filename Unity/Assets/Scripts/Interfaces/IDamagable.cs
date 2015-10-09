using UnityEngine;
using System.Collections;

public interface IDamagable<T> {
    //void Damaged(T damageTaken);

    void TakeDamage(T damageTaken);
}
