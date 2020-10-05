using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixItem : MonoBehaviour
{
    public Image Icon;

    public void setIcon(Sprite sprite)
    {
        Icon.sprite = sprite;
    }
}
