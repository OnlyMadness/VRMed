namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;

    public class GrabObject_v2 : VRTK_InteractableObject
    {
       // private GameObject bullet;
        public bool Founded;
        Material fsdf;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
                  
            base.StartUsing(usingObject);

            //  FireBullet();
        }
        public override void StopUsing(VRTK_InteractUse usingObject)
        {    
            StartCoroutine(Hide());
            base.StopUsing(usingObject);
        }
        IEnumerator Hide()
        {
            //gameObject.GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);   //Opaque
            //gameObject.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            //gameObject.GetComponent<Renderer>().material.SetInt("_ZWrite", 1);
            //gameObject.GetComponent<Renderer>().material.DisableKeyword("_ALPHATEST_ON");
            //gameObject.GetComponent<Renderer>().material.DisableKeyword("_ALPHABLEND_ON");
            //gameObject.GetComponent<Renderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            //gameObject.GetComponent<Renderer>().material.renderQueue = -1;
            for (int i = 0; i < gameObject.GetComponent<Renderer>().materials.Length; i++)
            {
                gameObject.GetComponent<Renderer>().materials[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);            //Fade
                gameObject.GetComponent<Renderer>().materials[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                gameObject.GetComponent<Renderer>().materials[i].SetInt("_ZWrite", 0);
                gameObject.GetComponent<Renderer>().materials[i].DisableKeyword("_ALPHATEST_ON");
                gameObject.GetComponent<Renderer>().materials[i].EnableKeyword("_ALPHABLEND_ON");
                gameObject.GetComponent<Renderer>().materials[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");
                gameObject.GetComponent<Renderer>().materials[i].renderQueue = 3000;
            }
            while (gameObject.GetComponent<Renderer>().material.color.a >= 0.06f)
            {             
                for (int i = 0; i < gameObject.GetComponent<Renderer>().materials.Length; i++)
                {
                    var color = gameObject.GetComponent<Renderer>().materials[i].color;
                    gameObject.GetComponent<Renderer>().materials[i].color = new Color(color.r, color.g, color.b, color.a - 0.05f);
                }
                yield return new WaitForSeconds(0.01f);
            }
            Destroy(gameObject);
            StopCoroutine(Hide());
        }
        protected void Start()
        {
          //  bullet = transform.Find("Bullet").gameObject;
           // bullet.SetActive(false);
        }

       
    }
}