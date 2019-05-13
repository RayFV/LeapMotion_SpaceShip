using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity;

public class LeapMouse : MonoBehaviour {
    
    public GameObject handModle;
    public RigidHand hand;
    public RigidFinger[] fingers;
    public Color positColor;
    public float fingerDataLimit;

    public bool waitLock = true;
    public float waitLockTime = 2;
    
    private Color originColor;
    private Button button;

    // Use this for initialization
    void Start () {
        originColor = GetComponent<Image>().color;
	}

    void Update()
    {
        if (hand.gameObject.activeSelf)
        {
            this.transform.localScale = Vector3.one;
            transform.position = Camera.main.WorldToScreenPoint(hand.GetPalmPosition());

            float fingerData = 0.0f;
            foreach (RigidFinger finger in fingers)
            {
                fingerData += finger.GetFingerJointStretchMecanim(1);
            }
            if (fingerData < fingerDataLimit)
            {
                gameObject.GetComponent<Image>().color = positColor;
                if (button != null && !waitLock)
                    button.onClick.Invoke();
            }
            else
            {
                gameObject.GetComponent<Image>().color = originColor;
            }
        }
        else
        {
            this.transform.localScale = Vector3.zero;
        }
            
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        handModle.transform.localScale = Vector3.one;
        StartCoroutine(WaitedEnable());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        button = collision.gameObject.GetComponent<Button>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        button = null;
    }

    IEnumerator WaitedEnable()
    {
        yield return new WaitForSeconds(waitLockTime);
        waitLock = false;
    }
}
