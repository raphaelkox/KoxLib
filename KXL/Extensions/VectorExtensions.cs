using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 To3DPlane(this Vector2 vector2) {
            return new Vector3(vector2.x, 0, vector2.y);
        }

        public static Vector3 CopyX(this Vector3 vector, Vector3 other) {
            return new Vector3(other.x, vector.y, vector.z);
        }

        public static Vector3 CopyY(this Vector3 vector, Vector3 other) {
            return new Vector3(vector.x, other.y, vector.z);
        }

        public static Vector3 CopyZ(this Vector3 vector, Vector3 other) {
            return new Vector3(vector.x, vector.y, other.z);
        }
    }
}