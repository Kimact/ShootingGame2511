using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HScrollManager : MonoBehaviour , IManager
{
    public List<IScroller> scrollers = new List<IScroller>();

    [SerializeField] private float scrollSpeed = 4f;

    public void GameInitialize()
    {
        scrollers.Clear();
        scrollers - InterfaceFinder.FindObjectsOfInterface2<IScroller>();
    }

    public void GameOver()
    {
        throw new System.NotImplementedException();
    }

    public void GamePause()
    {
        throw new System.NotImplementedException();
    }

    public void GameResume()
    {
        throw new System.NotImplementedException();
    }

    public void GameStart()
    {
        throw new System.NotImplementedException();
    }

    public void GameTick(float delta)
    {
        throw new System.NotImplementedException();
    }
}
