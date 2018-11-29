using UnityEngine;

public class ScreenHidden : MonoBehaviour
{

    public GameObject blackScreen;

    private void FixedUpdate()
    {
        var cam = Camera.main.transform;
        var ray = new Ray(cam.position, cam.forward);
        RaycastHit hit;
        blackScreen.SetActive(!Physics.Raycast(ray, out hit, 1000));
    }
}