using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlagmentPresenter : MonoBehaviour, IFragmentable
{
    [SerializeField]
    FragmentType fragmentType;
    public FragmentType FragmentType => fragmentType;

    void Start()
    {
        
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
