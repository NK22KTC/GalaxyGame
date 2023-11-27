using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralSettings", menuName = "ScriptableObjects/Create GeneralSettings")]
public class GeneralSettings : ScriptableObject
{
    private const string path = "Settings/GeneralSettings";
    private static GeneralSettings instance;

    public static GeneralSettings Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = Resources.Load<GeneralSettings>(path);
                if(instance == null)
                {
                    Debug.LogError(path + "ã‚ÉGeneralSettings‚ª‚ ‚è‚Ü‚¹‚ñ");
                }
            }
            return instance;
        }
    }

    [SerializeField]
    private PlayerSettings PlayerSettings;
    [SerializeField]
    private EnemySettings EnemySettings;

    public PlayerSettings m_PlayerSettings { get => PlayerSettings; }
    public EnemySettings m_EnemySettings { get => EnemySettings; }
}
