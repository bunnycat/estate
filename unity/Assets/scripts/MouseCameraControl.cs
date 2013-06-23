//
//Filename: MouseCameraControl.cs
//
 
using UnityEngine;
 
[AddComponentMenu("Camera-Control/Mouse")]
public class MouseCameraControl : MonoBehaviour
{
  private Vector3   mAim      = Vector3.zero;
  private Vector3   mRotation = new Vector3(45.0f, 0.0f, 0.0f);
  private float     mDistance = 10.0f;

  private Vector3   mBaseAim;
  private Vector3   mBasePoint;

  //
  // MonoBehaviour
  //

  void Start()
  {
    SetAim(mAim, mRotation, mDistance);
  }

  void Update()
  {
    Plane plane = new Plane(Vector3.up, 0.0f);

    if (Input.GetMouseButtonDown(0))
    {
      Ray ray = camera.ScreenPointToRay(Input.mousePosition);
      float distance = 0.0f;
      plane.Raycast(ray, out distance);

      mBaseAim   = mAim;
      mBasePoint = ray.GetPoint(distance);
    }

    if (Input.GetMouseButton(0))
    {
      SetAim(mBaseAim, mRotation, mDistance);

      Ray ray = camera.ScreenPointToRay(Input.mousePosition);
      float distance = 0.0f;
      plane.Raycast(ray, out distance);

      Vector3 newPoint = ray.GetPoint(distance);

      SetAim(mBaseAim + mBasePoint - newPoint, mRotation, mDistance);
    }
    else
    if (Input.GetMouseButton(1))
    {
      mRotation.y = mRotation.y + 1.0f;

      SetAim(mAim, mRotation, mDistance);
    }

  }

  void SetAim(Vector3 aim, Vector3 angles, float distance)
  {
//    Vector3 angles = camera.transform.eulerAngles;

    float sinPhi   = Mathf.Sin(Mathf.Deg2Rad * angles.x);
    float cosPhi   = Mathf.Cos(Mathf.Deg2Rad * angles.x);
    float sinTheta = Mathf.Sin(Mathf.Deg2Rad * angles.y);
    float cosTheta = Mathf.Cos(Mathf.Deg2Rad * angles.y);

    float x = aim.x - sinTheta * cosPhi * distance;
    float y = aim.y + sinPhi * distance;
    float z = aim.z - cosTheta * cosPhi * distance;;

    camera.transform.position = new Vector3(x, y, z);
    camera.transform.eulerAngles = angles;

    mAim      = aim;
    mRotation = angles;
    mDistance = distance;
  }
}