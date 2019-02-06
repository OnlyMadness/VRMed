namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;

    public class GrabObject_v2 : VRTK_InteractableObject
    {
       // private GameObject bullet;
        public bool Founded; 
        

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
            while (gameObject.GetComponent<Renderer>().material.color.a >= 0.06f)
            {
  
                //gameObject.GetComponent<Rigidbody>().isKinematic = false;
                var color = gameObject.GetComponent<Renderer>().material.color;
                gameObject.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, color.a-0.05f);
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