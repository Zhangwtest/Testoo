using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public int index { get; private set; } = 0;

    public void SetIndex(int index)
    {
        this.index = index;
    }
}
