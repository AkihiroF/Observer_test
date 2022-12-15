using System.Collections.Generic;
using _Source.Observable;
using DG.Tweening;
using UnityEngine;

namespace _Source.Observer
{
    public class Sky : IObserver
    {
        public Sky(IObservable observable, Camera camera, List<Color> colors, float timePhase)
        {
            _observable = observable;
            _observable.RegisterObserver(this);
            _camera = camera;
            _colors = colors;
            _timePhase = timePhase;
        }

        private IObservable _observable;
        private Camera _camera;
        private List<Color> _colors;
        private float _timePhase;

        public void Update(int phase)
        {
            _camera.DOColor(_colors[phase], _timePhase);
        }
    }
}