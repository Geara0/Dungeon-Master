using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
    void Shoot();
    Sprite getSprite();
    string getPrice();
}