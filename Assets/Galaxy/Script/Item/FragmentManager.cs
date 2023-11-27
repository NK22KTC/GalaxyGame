using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FragmentType
{
    Guide, //“±‚«
    Mark,  //ˆó
    Light  //“”
}

public class FragmentManager
{
    private FragmentType fragmentType;
    public FragmentType FragmentType { get => fragmentType; }


    public FragmentManager(FragmentType fragmentType)
    {
        this.fragmentType = fragmentType;
    }
}

