namespace VRTK.Examples
{
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

        protected void Start()
        {
          //  bullet = transform.Find("Bullet").gameObject;
           // bullet.SetActive(false);
        }

       
    }
}