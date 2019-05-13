using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {

    public Color fullColor;
    public Color unfullColor;
    public Image frontImage;

    public bool hasThirdColor;
    public Color thirdColor;
    [Range(0.01f, 0.99f)]
    public float thirdColorValue;

    public float maxValue;
    public float reloadValue;
    public float consumeValue;

    private bool isReload = true;
    private float value;

    private void Start()
    {
        FixedValue(maxValue);
    }


    // Update is called once per frame
    void FixedUpdate () {
        if (isReload)
        {
            FixedValue(reloadValue);
        }
        else
        {
            FixedValue(-consumeValue);
        }
	}

    public void FixedValue(float delta)
    {
        value += delta;

        if (value > maxValue)
            value = maxValue;
        else if (value < 0)
            value = 0;

        frontImage.fillAmount = value / maxValue;

        if (value == maxValue)
            frontImage.color = fullColor;
        else
            frontImage.color = unfullColor;

        if (hasThirdColor && value / maxValue <= thirdColorValue)
            frontImage.color = thirdColor;
    }


    public void ChangeStatus(bool isReload)
    {
        this.isReload = isReload;
    }

    public void ConsumeAllEnergy()
    {
        value = 0;
        frontImage.fillAmount = 0;
    }

    public bool IsFull()
    {
        return value == maxValue;
    }

    public bool IsEmpty()
    {
        return value == 0;
    }
}
