using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Abstracts.Interfaces
{
    public interface IBullet
    {
        abstract void GiveDamage(Collider other);

    }
}

