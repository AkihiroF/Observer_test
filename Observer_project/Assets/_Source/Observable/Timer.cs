using System;
using System.Collections.Generic;
using _Source.Observer;
using DG.Tweening;
using DG.Tweening;
using UnityEngine;

namespace _Source.Observable
{
    public class Timer : IObservable
    {
        private List<IObserver> _obsevers;
        private float _timePhase;
        private int _currentPhase;
        private int _countPhase;

        public Timer(float timePhase, int countPhase)
        {
            _countPhase = countPhase;
            _timePhase = timePhase;
            _obsevers = new List<IObserver>();
        }
        
        public void RegisterObserver(IObserver obj)
        {
            _obsevers.Add(obj);
        }

        public void RemoveObserver(IObserver obj)
        {
            try
            {
                _obsevers.Remove(obj);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        private void Wait()
        {
            if (_currentPhase == _countPhase) _currentPhase = 0;
            float one = 0;
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(DOTween.To(() => one, x => one = x, 12, _timePhase )).AppendCallback(() => Notify());
        }

        public void Notify()
        {
            foreach (var observer in _obsevers)
            {
                observer.Update(_currentPhase);
            }

            _currentPhase++;
            Wait();
        }
    }
}