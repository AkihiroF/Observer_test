using System.Collections.Generic;
using _Source.Observable;
using DG.Tweening;
using UnityEngine;

namespace _Source.Observer
{
    public class Stars : IObserver
    {
        public Stars(IObservable observable, List<float> alphas, SpriteRenderer stars, float timePhase)
        {
            _observable = observable;
            _observable.RegisterObserver(this);
            _alphas = alphas;
            _stars = stars;
            _timePhase = timePhase;
        }

        private IObservable _observable;
        private List<float> _alphas;
        private SpriteRenderer _stars;
        private float _timePhase;
        public void Update(int phase)
        {
            _stars.DOFade(_alphas[phase], _timePhase);
        }
    }
}