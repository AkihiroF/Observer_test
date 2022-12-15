using System.Collections.Generic;
using _Source.Observable;
using DG.Tweening;
using UnityEngine;

namespace _Source.Observer
{
    public class Sun : IObserver
    {
        public Sun(IObservable observable, List<Transform> positions, Transform body, float timePhase)
        {
            _observable = observable;
            _observable.RegisterObserver(this);
            _positions = new List<Vector3>();
            positions.ForEach(i => _positions.Add(i.position));
            _body = body;
            _timePhase = timePhase;
        }

        private IObservable _observable;
        private List<Vector3> _positions;
        private Transform _body;
        private float _timePhase;

        public void Update(int phase)
        {
            _body.DOMove(_positions[phase], _timePhase);
        }
    }
}