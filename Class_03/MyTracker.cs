using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class MyTracker : MonoBehaviour
{
    string output;
    ARTrackedImageManager m_TrackedImageManager;
    public Text text;

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void UpdateInfo(ARTrackedImage trackedImage)
    {
        if (trackedImage.referenceImage.name == "Rafflesia")
        {
            trackedImage.GetComponent<itp.Tracked>().Choose(0);
        }
        if (trackedImage.referenceImage.name == "Logo")
        {
            trackedImage.GetComponent<itp.Tracked>().Choose(1);
        }
        if (trackedImage.referenceImage.name == "QRCode")
        {
            trackedImage.GetComponent<itp.Tracked>().Choose(2);
        }

        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            trackedImage.transform.localScale = new Vector3(trackedImage.size.x, trackedImage.size.x, trackedImage.size.y);
            //trackedImage.GetComponent<Renderer>().material.mainTexture = (trackedImage.referenceImage.texture == null) ? null : trackedImage.referenceImage.texture;
        }
        else
        {
            trackedImage.GetComponent<itp.Tracked>().Choose(-1);
        }
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            text.text = trackedImage.size.x + "\n" + trackedImage.referenceImage.name + "\n";
            trackedImage.GetComponent<itp.Tracked>().Enable();
            UpdateInfo(trackedImage);
        }

     
        foreach (var trackedImage in eventArgs.updated)
            UpdateInfo(trackedImage);
            
    }
}
