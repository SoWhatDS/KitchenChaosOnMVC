using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class BaseController : IDisposable
{
    private List<GameObject> _gameObjects;
    private List<BaseController> _baseControllers;
    private bool _isDisposed;

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        _isDisposed = true;

        DisposeBaseControllers();
        DisposeGameObjects();

        OnDispose();
        
    }

    private void DisposeGameObjects()
    {
        if (_gameObjects == null)
        {
            return;
        }

        foreach (GameObject gameObject in _gameObjects)
        {
            Object.Destroy(gameObject);
        }

        _gameObjects.Clear();
    }

    private void DisposeBaseControllers()
    {
        if (_baseControllers == null)
        {
            return;
        }

        foreach (BaseController baseController in _baseControllers)
        {
            baseController.Dispose();
        }

        _baseControllers.Clear();
    }

    protected virtual void OnDispose() { }

    protected void AddControllers(BaseController controller)
    {
        _baseControllers ??= new List<BaseController>();
        _baseControllers.Add(controller);
    }

    protected void AddGameObjects(GameObject gameObject)
    {
        _gameObjects ??= new List<GameObject>();
        _gameObjects.Add(gameObject);
    }
}
