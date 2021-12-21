using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Utilities
{
    public class EdgeColliderVisual : MonoBehaviour
    {
        public EdgeCollider2D edge;

        private void OnDrawGizmos() {
            List<Vector2> points = new List<Vector2>();
            var num = edge.GetPoints(points);
            var r = edge.edgeRadius;
            Vector2 a, b, d, n;

            Gizmos.DrawWireSphere(points[0], r);
            for (int i = 1; i < num; i++) {
                a = points[i - 1];
                b = points[i];
                d = b - a;
                n.x = d.y;
                n.y = -d.x;
                n.Normalize();

                Gizmos.DrawWireSphere(points[i], r);
                Gizmos.DrawLine(points[i - 1] + n * r, points[i] + n * r);
                Gizmos.DrawLine(points[i - 1] - n * r, points[i] - n * r);
            }
        }
    }
}