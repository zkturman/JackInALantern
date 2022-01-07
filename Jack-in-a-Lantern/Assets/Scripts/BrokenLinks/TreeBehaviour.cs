//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TreeBehaviour : MonoBehaviour, ICollidable
//{
//    [SerializeField] private AudioSource collideNoise;
//    public void StartCollision()
//    {
//        collideNoise.Play();
//    }

//    public void UpdateOtherStats(GameObject statsToChange)
//    {
//        throw new System.NotImplementedException();
//    }

//    public void UpdateThisStats()
//    {
//        throw new System.NotImplementedException();
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.TryGetComponent<IControllable>(out IControllable player))
//        {
//            StartCollision();
//        }   
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
