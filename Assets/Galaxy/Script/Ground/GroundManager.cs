using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour, IGroundGimmick
{
    private bool m_GimmickTriggerd = false;
    private bool m_GimmickCleard = false;

    public bool GimmickTriggerd => m_GimmickTriggerd;
    public bool GimmickCleard => m_GimmickCleard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtle()
    {
        if (m_GimmickTriggerd) return;

        Debug.Log("êÌì¨äJén");
        m_GimmickTriggerd = true;
    }

    public void MakeWarpMaker()
    {

    }
}
