// Fixed Joint Grab Attach|GrabAttachMechanics|50040
namespace VRTK.GrabAttachMechanics
{
    using System;
    using UnityEngine;
    using VRTK.Examples;

    /// <summary>
    /// The Fixed Joint Grab Attach script is used to create a simple Fixed Joint connection between the object and the grabbing object.
    /// </summary>
    /// <example>
    /// `VRTK/Examples/005_Controller_BasicObjectGrabbing` demonstrates this grab attach mechanic all of the grabbable objects in the scene.
    /// </example>
    [AddComponentMenu("VRTK/Scripts/Interactions/Grab Attach Mechanics/VRTK_FixedJointGrabAttach")]
    public class VRTK_FixedJointGrabAttach : VRTK_BaseJointGrabAttach
    {
        [Tooltip("Maximum force the joint can withstand before breaking. Infinity means unbreakable.")]
        public float breakForce = 1500f;
        public GameObject GreenObjects;
        public GameObject CircleObjects;
        public GameObject Canvas_Select_Type_Objects;
        protected override void CreateJoint(GameObject obj)
        {
            if (obj.name == "Legal_pad_Green")
            {
                Debug.Log("Green");
                CircleObjects.SetActive(false);
                GameControllerFindObjects.TypeObjects = "Green";
                GameControllerFindObjects.StartGameBool = true;

                Canvas_Select_Type_Objects.GetComponent<VRTK_UICanvas>().enabled = false;
                Canvas_Select_Type_Objects.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                Canvas_Select_Type_Objects.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);

                OnPointer();
                return;
            }
            if (obj.name == "Soccer Ball_Circle")
            {
                Canvas_Select_Type_Objects.GetComponent<VRTK_UICanvas>().enabled = false;
                Canvas_Select_Type_Objects.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                Canvas_Select_Type_Objects.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);

                GreenObjects.SetActive(false);
                Debug.Log("Circle");
                GameControllerFindObjects.StartGameBool = true;
                GameControllerFindObjects.TypeObjects = "Circle";
                OnPointer();
                return;
            }
            if (obj.GetComponent<GrabObject>().Founded == false)
            {
                obj.GetComponent<GrabObject>().Founded = true;
                if (obj.transform.parent.gameObject.name == "Circle Objects")
                    GameControllerFindObjects.Founded_Circles++;
                if (obj.transform.parent.gameObject.name == "Green Objects")
                    GameControllerFindObjects.Founded_Green++;
            }
            givenJoint = obj.AddComponent<FixedJoint>();
            givenJoint.breakForce = (grabbedObjectScript.IsDroppable() ? breakForce : Mathf.Infinity);
            base.CreateJoint(obj);
        }

        private void OnPointer()
        {
           //Включить поинтер
        }
    }
}