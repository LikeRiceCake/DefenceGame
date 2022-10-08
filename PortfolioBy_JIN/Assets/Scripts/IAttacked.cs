using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacked
{
    void Attacked(int _damage);
    Collider2D GetOpponent();
}
