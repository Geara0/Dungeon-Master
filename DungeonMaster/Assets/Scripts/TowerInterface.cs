using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
    IEnumerator DoFire();
    void Shoot();
    Sprite getSprite();
    string getPrice();
}