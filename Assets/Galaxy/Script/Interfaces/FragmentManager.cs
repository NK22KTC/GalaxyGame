using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemDestroyable
{
    void DestroyItem();
}

public interface IFragmentable: IItemDestroyable
{
    public FragmentType FragmentType { get; }
}