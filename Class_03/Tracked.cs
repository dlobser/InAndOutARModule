using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace itp
{
    public class Tracked : MonoBehaviour
    {
        bool disabling = false;

        void Start()
        {

        }

        void Update()
        {

        }

        public void Choose(int which)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
            if(which>=0 && which<this.transform.childCount)
                this.transform.GetChild(which).gameObject.SetActive(true);
        }

        public void Enable()
        {
            StartCoroutine(Grow());
        }

        public void Disable()
        {
            if (!disabling)
            {
                StartCoroutine(Shrink());
                disabling = true;
            }
        }

        IEnumerator Grow()
        {
            float count = 0;
            while (count < 1)
            {
                count += Time.deltaTime;
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    this.transform.GetChild(i).localScale = new Vector3(count, count, count);
                }
                yield return null;

            }
            disabling = false;
        }

        IEnumerator Shrink()
        {
            float count = 1;
            while (count > 1)
            {
                count -= Time.deltaTime;

                for (int i = 0; i < this.transform.childCount; i++)
                {
                    this.transform.GetChild(i).localScale = new Vector3(count, count, count);
                }
                yield return null;

            }
        }
    }
}