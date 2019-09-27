using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKat.MathW
{
    public class MathW
    {
        public static Vector2 SetVector(Vector2 vector, int position, float desiredValue)
        {
            switch (position)
            {
                case 0:
                    vector.x = desiredValue;
                    break;
                case 1:
                    vector.y = desiredValue;
                    break;
                default:
                    break;
            }
            return vector;
        }
    }
}