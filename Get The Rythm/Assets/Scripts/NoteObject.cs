using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject normalHitEffect, goodHitEffect, perfectHitEffect, missHitEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                if(Mathf.Abs(transform.position.y) > 0.25f)
                {
                    Debug.Log("Normal");
                    GameManager.instance.NormalHit();
                    Instantiate(normalHitEffect, transform.position, normalHitEffect.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodHitEffect, transform.position, goodHitEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectHitEffect, transform.position, perfectHitEffect.transform.rotation);
                }
                //GameManager.instance.NoteHit();
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeSelf)
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;
                GameManager.instance.NoteMissed();
                Instantiate(missHitEffect, transform.position, missHitEffect.transform.rotation);
            }
        }
    }


}
