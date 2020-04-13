using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


namespace Interaction
{
    public class EventInteractable_TriggerBall : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
        IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        public Animator animator;
        public AudioSource audio;

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Drag Begin");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Dragging");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("Drag Ended");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked: " + eventData);//eventData.pointerCurrentRaycast.gameObject.name);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
            //this.GetComponent<MeshRenderer>().material.color = Color.red;
            animator.SetTrigger("play");
            StartCoroutine(changeColor());
            audio.Play();
            audio.pitch = Random.Range(.5f, 1);
        }

        IEnumerator changeColor()
        {
            float count = 0;
            Color A = Random.ColorHSV();
            Color B = Color.white;
            while (count < 1)
            {
                count += Time.deltaTime;
                this.GetComponent<MeshRenderer>().material.color = Color.Lerp(A, B, count);
                yield return null;

            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Mouse Enter");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Mouse Exit");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("Mouse Up");
            this.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}