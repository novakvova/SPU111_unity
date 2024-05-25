using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasText : MonoBehaviour
{
    int m_IndexNumber;
    // Start is called before the first frame update
    void Start()
    {
        m_IndexNumber = 0;
        transform.SetSiblingIndex(m_IndexNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
