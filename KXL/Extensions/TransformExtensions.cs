using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Extensions
{
    public static class TransformExtensions
    {
        public static Transform SetX(this Transform transform, float x) {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            return transform;
        }

        public static Transform SetY(this Transform transform, float y) {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            return transform;
        }

        public static Transform SetZ(this Transform transform, float z) {
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
            return transform;
        }
    }
}
