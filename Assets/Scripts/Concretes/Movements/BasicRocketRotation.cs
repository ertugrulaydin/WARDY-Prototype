using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Bullets;


namespace WARDY.Movements
{
    public class BasicRocketRotation
    {
        BasicRocket _basicRocket;

        Rigidbody _rigidbody;

        public BasicRocketRotation(BasicRocket basicRocket, Rigidbody rigidbody)
        {

            _basicRocket = basicRocket;
            _rigidbody = rigidbody;

        }

        public void FixedTick()
        {

            _basicRocket.transform.Rotate(0, 0, 15);

        }
    }
}

