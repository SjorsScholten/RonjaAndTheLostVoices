using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observable {
    public readonly List<IObserver> observers = new List<IObserver>();

    public void Attatch(IObserver observer) {
        observers.Add(observer);
    }

    public void Detatch(IObserver observer) {
        observers.Remove(observer);
    }

    public void Notify() {
        foreach (IObserver observer in observers) {
            observer.Update();
        }
    }
}
