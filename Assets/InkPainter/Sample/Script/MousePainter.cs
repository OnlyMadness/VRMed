using UnityEngine;
using System.Collections;

namespace Es.InkPainter.Sample
{
	public class MousePainter : MonoBehaviour
	{
		/// <summary>
		/// Types of methods used to paint.
		/// </summary>
		[System.Serializable]
		private enum UseMethodType
		{
			RaycastHitInfo,
			WorldPoint,
			NearestSurfacePoint,
			DirectUV,
		}

		[SerializeField]
		private Brush brush;

		[SerializeField]
		private UseMethodType useMethodType = UseMethodType.RaycastHitInfo;

		[SerializeField]
		bool erase = false;

        private Vector2 Old_UV;
        public Vector3 HitPoint;

        public float DrawDistance;
        public float DragDistance;
        public LayerMask layerMask;

        public bool CanDraw = true;

        private void Update()
		{
            Vector3 forward = transform.TransformDirection(Vector3.up);

            var ray = new Ray(transform.position, forward);

            bool success = true;

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, DragDistance, layerMask)) HitPoint = hitInfo.point;

            if (Physics.Raycast(ray, out hitInfo) && hitInfo.transform.tag == "MiniGame_DragObject" || !CanDraw)
            {
                return;
            }
            
            if (Physics.Raycast(ray, out hitInfo) && hitInfo.distance < DrawDistance)
            {
                var paintObject = hitInfo.transform.GetComponent<InkCanvas>();

                if (paintObject != null)
                    switch (useMethodType)
                    {
                        case UseMethodType.RaycastHitInfo:
                            success = erase ? paintObject.Erase(brush, hitInfo) : paintObject.Paint(brush, hitInfo);
                            break;

                        case UseMethodType.WorldPoint:
                            success = erase ? paintObject.Erase(brush, hitInfo.point) : paintObject.Paint(brush, hitInfo.point);
                            break;

                        case UseMethodType.NearestSurfacePoint:
                            success = erase ? paintObject.EraseNearestTriangleSurface(brush, hitInfo.point) : paintObject.PaintNearestTriangleSurface(brush, hitInfo.point);
                            break;

                        case UseMethodType.DirectUV:
                            if (!(hitInfo.collider is MeshCollider))
                                Debug.LogWarning("Raycast may be unexpected if you do not use MeshCollider.");
                            success = erase ? paintObject.EraseUVDirect(brush, hitInfo.textureCoord) : paintObject.PaintUVDirect(brush, hitInfo.textureCoord);
                                                        
                            StartCoroutine(SmoothLine(paintObject, hitInfo.textureCoord, Old_UV));

                            Old_UV = hitInfo.textureCoord;

                            break;
                    }

                if (!success)
                    Debug.LogError("Failed to paint.");
            }
            else { Old_UV = hitInfo.textureCoord; }
		}

        IEnumerator SmoothLine(InkCanvas paintObject, Vector2 _newUV, Vector2 _oldUV)
        {
            if (_oldUV.x == 0 && _oldUV.y == 0) _oldUV = _newUV;

            float _dist = Vector2.Distance(_newUV, _oldUV);

            int i = 1;

            if (_dist < 0.005f || _dist > 0.05f) yield break;

            while (i < 5)
            {                
                paintObject.PaintUVDirect(brush, Vector2.Lerp(_newUV, _oldUV, i*0.2f));
                i++;
            }
            yield break;
        }

		public void ResetAll()
		{
            foreach(var canvas in FindObjectsOfType<InkCanvas>())
            canvas.ResetPaint();
		}
	}
}