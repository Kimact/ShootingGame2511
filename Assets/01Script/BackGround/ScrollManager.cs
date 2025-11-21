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
        throw new System.NotImplementedException();
    }

    public void GameTick(float delta)
    {
        foreach(IScroller c in scrollers)
        {
            c.SetScrollSpeed(scrollSpeed);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
