using System.Collections.Generic;
using _Source.Observable;
using _Source.Observer;
using UnityEngine;

namespace _Source.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private List<Transform> positionsSun;
        [SerializeField] private Transform bodySun;
        [SerializeField] private  List<Color> colorsSky;
        [SerializeField] private Camera camera;
        [SerializeField] private List<float> alphasStars;
        [SerializeField] private SpriteRenderer starsBody;
        [SerializeField] private float timePhase;

        private void Awake()
        {
            var timer = new Timer(timePhase, positionsSun.Count);
            var sun = new Sun(timer, positionsSun, bodySun, timePhase);
            var sky = new Sky(timer, camera, colorsSky, timePhase);
            var stars = new Stars(timer, alphasStars, starsBody, timePhase);

            var game = new Game(timer);
            game.StartGame();
        }
    }
}