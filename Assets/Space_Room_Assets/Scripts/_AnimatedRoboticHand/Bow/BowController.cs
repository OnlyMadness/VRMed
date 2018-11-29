namespace Formika
{
    using System;
    using UnityEngine;
    using System.Collections;

    public class BowController : MonoBehaviour
    {
        private enum State
        {
            HiddenArrow, ShowArrow, ReadyArrow
        }

        public static event Action OnShowArrow, OnHideArrow, OnReadyArrow;
        public float VarDistance;
        public Transform InstancePosition;
        public Transform m_bowTransform, m_bowstringTransform;
        public GameObject m_arrowPrefab, m_arrowInstance;
        public float m_showArrowDistMin, m_showArrowDistMax;
        public Animation Anim;
        public float AnimBacksTime = 1.0f;
        private float alphaValue;

        private State state;

        private void Start()
        {
            {
                var clipName = Anim.clip.name;
                Anim.Play();
                Anim[clipName].speed = 0f;
               
            }


            state = State.HiddenArrow;

            //DEBUG
            OnHideArrow += () => { Debug.Log("Event: OnHideArrow"); };
            OnShowArrow += () => { Debug.Log("Event: OnShowArrow"); };
            OnReadyArrow += () => { Debug.Log("Event: OnReadyArrow"); };
        }

        private void Update()
        {
            UpdateBowDistance();
        }
        public void Ungrab()
        {

            if (state == State.ReadyArrow)
            {

                //  var ChidArrow = gameObject.transform.Find("BasicArrow(Clone)");
                //Debug.Log(ChidArrow.ToString());
                if (gameObject.GetComponentInChildren<ArrowForce>() != null)
                {
                    gameObject.GetComponentInChildren<ArrowForce>().Shoot(alphaValue);
                    m_arrowInstance = null;
                    Debug.Log("UngrabArrow");
                }
            }
            else
            {
                DestroyImmediate(m_arrowInstance);
                m_arrowInstance = null;
            }

            StartCoroutine(AnimToStart(AnimBacksTime));


        }

        public IEnumerator AnimToStart(float timeAnim)
        {
            state = State.HiddenArrow;

            /*   float currentTime = 0.0f;

               while (currentTime < timeAnim)
               {
                   currentTime += Time.deltaTime;
                   var clipName = Anim.clip.name;
                   Anim[clipName].time = Mathf.Lerp(1.0f, 0.0f, Time.deltaTime * timeAnim);
                   yield return new WaitForEndOfFrame();
               }
               */
            string clipName = Anim.clip.name;
            float currentTime = Anim[clipName].time;

            while (Anim[clipName].time > 0.01f)
            {                
                Anim[clipName].time = Mathf.Lerp(currentTime, 0.0f, Time.deltaTime * timeAnim);
                yield return new WaitForEndOfFrame();
            }

        }
        private void UpdateBowDistance()
        {
            var currentDistance = Vector3.Distance(m_bowTransform.position, m_bowstringTransform.position);

            if (currentDistance < m_showArrowDistMin)
            {
                //Скрываем если стрела уже была
                if (state != State.HiddenArrow)
                {
                    // удаляем стрелу
                    if (m_arrowInstance != null)
                        DestroyImmediate(m_arrowInstance);

                    state = State.HiddenArrow;
                    if (OnHideArrow != null)
                        OnHideArrow();
                }
            }
            else
            if (currentDistance > m_showArrowDistMin && currentDistance < m_showArrowDistMax)
            {
                // предыдущее состояние
                if (state == State.HiddenArrow)
                {
                    // создаем стрелу
                    m_arrowInstance = Instantiate(m_arrowPrefab, InstancePosition) as GameObject;
                }

                //Показываем с альфой
                if (state != State.ShowArrow)
                {
                    state = State.ShowArrow;
                    if (OnShowArrow != null)
                        OnShowArrow();
                }

                //Меняем альфу
                if (state == State.ShowArrow)
                {

                    var deltaPos = m_showArrowDistMax - m_showArrowDistMin;
                    VarDistance = Vector3.Distance(m_bowTransform.position, m_bowstringTransform.position);
                    var alpha = (currentDistance - m_showArrowDistMin) / deltaPos;
                    alphaValue = alpha;

                    if (m_arrowInstance != null)
                    {
                        // transparent
                        var renderer = m_arrowInstance.GetComponentInChildren<Renderer>();
                        /*
                        var color = renderer.material.color;
                        color.a = alpha;
                        renderer.material.color = color;
                        */

                        // scale
                        var childTransform = renderer.transform;
                        childTransform.localScale = new Vector3(0.007f * alpha, 0.17f, 0.007f * alpha);
                        //Debug.Log(alpha);
                    }

                    var clipName = Anim.clip.name;
                    Anim[clipName].time = Anim.clip.length * alpha;
                }
            }
            else
            if (currentDistance > m_showArrowDistMax)
            {
                //готовы к выстрелу
                if (state != State.ReadyArrow)
                {
                    state = State.ReadyArrow;
                    if (OnReadyArrow != null)
                        OnReadyArrow();
                }
            }
            //else
            //    if (currentDistance < m_showArrowDistMin)
            //{
            //    if (m_arrowInstance != null)
            //    {
            //        DestroyImmediate(m_arrowInstance);
            //        Debug.Log("DestroyArrowOnBow");
            //    }
          //  }
        }
    }
}