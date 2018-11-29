using UnityEngine;

public class MiniGamesDisableAllColliders : MonoBehaviour {

    public static int click_counter;

    public Collider[] colliders;

    private bool check;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            foreach (Collider _col in colliders)
            {
                if (_col != GetComponent<Collider>()) _col.enabled = false;
                else
                {
                    if (!check)
                    {
                        check = true;
                        click_counter++;
                        if (click_counter == 12)
                        {
                            GetComponent<MiniGamesDragObjs>().EnableDraw();
                        }
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        check = false;
        click_counter = 0;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            foreach (Collider _col in colliders)
            {
                _col.enabled = true;
            }
        }
    }
 }
