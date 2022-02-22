using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using UnityEngine.EventSystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    [SerializeField] private Camera aRCamera;
    [SerializeField] private GameObject placementIndicator;
    public float rotateSpeed;

    private Pose _placementPose;
    private ARRaycastManager _aRRaycastManager;
    private bool _placementPoseIsValid;
    private Touch _touch;
    private GameObject _movingFurniture;
    List<ARRaycastHit> _centerHits = new List<ARRaycastHit>();
    List<ARRaycastHit> _touchHits = new List<ARRaycastHit>();

    
    
    void Start()
    {
        _movingFurniture = null;
        _aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void FixedUpdate()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (Input.touchCount <= 0) return;  // done with update if there is no touch.
        
        _touch = Input.GetTouch(0);

        if (IsTouchOnUI(_touch)) return;    // if the touch is on the UI, we are done and the button-logics will kick in.
        
        if (!_aRRaycastManager.Raycast(_touch.position, _touchHits)) return;    // if we touch something non-trackable, we return
        
        if (_touch.phase == TouchPhase.Began && _movingFurniture == null)   // if we start touching something trackable, e.g. a plane.
        {
            Ray ray = aRCamera.ScreenPointToRay(_touch.position);

            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.CompareTag("Hitbox"))
                {
                    var potentialFurniture = hit.collider.transform.parent.gameObject;
                    
                    if (potentialFurniture.CompareTag("PlayerSpawned")) // if we touch a furniture, we start moving it.
                    {
                        if (CurrentlySelectedObject.Instance.activeObject != default)
                        {
                            CurrentlySelectedObject.Instance.activeObject.GetComponent<ToggleHitbox>().hitboxOn = false;
                        }
                        _movingFurniture = potentialFurniture;
                        CurrentlySelectedObject.Instance.activeObject = _movingFurniture;
                        _movingFurniture.GetComponent<ToggleHitbox>().hitboxOn = true;
                        _movingFurniture.GetComponent<Rigidbody>().isKinematic = true; // we do not want physics while dragging/rotating object.
                    }
                }
                else
                {
                    PlaceObject();  // else, we place a furniture.
                }
            }
        }
        else if (_touch.phase == TouchPhase.Moved && _movingFurniture != null)  // update the position of the furniture being moved with the location of the touch.
        {
            foreach (var hitObj in _touchHits)
            {
                if ((hitObj.hitType & TrackableType.Planes) != 0)   // if we hit a trackable plane.
                {
                    _movingFurniture.transform.position = hitObj.pose.position;
                    break;  // we want to set the position of the furniture we moving to the first hit that's a plane. hence, the "break".
                }
            }
            //_movingFurniture.transform.position = _touchHits[0].pose.position;
        }
        
        else if (_touch.phase == TouchPhase.Stationary && _movingFurniture != null) // rotate furniture if player holds touch stationary
        {
            _movingFurniture.transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
        }

        if (_touch.phase ==
            TouchPhase.Ended) // if player has stopped touching with their finger, we are no longer moving any furniture.
        {
            _movingFurniture.GetComponent<Rigidbody>().isKinematic = false;
            _movingFurniture = null;
        }
        

    }

    private void UpdatePlacementPose()
    {
        var screenCenter = aRCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        _aRRaycastManager.Raycast(screenCenter, _centerHits, TrackableType.Planes);

        _placementPoseIsValid = _centerHits.Count > 0;
        if (_placementPoseIsValid)
        {
            _placementPose = _centerHits[0].pose;
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (_placementPoseIsValid)
        {
            placementIndicator.SetActive(true); 
            placementIndicator.transform.SetPositionAndRotation(_placementPose.position, _placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void PlaceObject()
    {
        Instantiate(HandleActiveItem.Instance.activeFurniture, _placementPose.position,
            _placementPose.rotation);
    }

    private static bool IsTouchOnUI(Touch activeTouch)
    {
        var eventData = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(activeTouch.position.x, activeTouch.position.y)
        };
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults.Count > 0;
    }
    
}
