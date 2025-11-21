using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour, IManager
{
    private List<IScroller> scrollers = new List<IScroller>();
    [SerializeField] private float scrollSpeed = 4;

    public void GameInitialize()
    {
        scrollers.Clear();
        scrollers = InterfaceFinder.FindObjectsOfInterface2<IScroller>();
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
        foreach(var c in scrollers)
        {
            c.SetScrollSpeed(scrollSpeed);
        }
    }

    public void GameTick(float delta)
    {
        foreach(IScroller c in scrollers)
        {
            c.SetScrollSpeed(scrollSpeed);
        }
    }

  
}
