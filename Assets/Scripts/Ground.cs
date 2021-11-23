using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    //初始值设为0.
    public int Index { get; private set; } = 0;

    public void SetIndex(int index)
    {
        this.Index = index;
    }
}
