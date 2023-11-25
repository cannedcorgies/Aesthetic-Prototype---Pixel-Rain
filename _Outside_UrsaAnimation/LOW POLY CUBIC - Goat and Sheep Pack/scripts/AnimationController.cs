using UnityEngine;

namespace Ursaanimation.CubicFarmAnimals
{

    public class AnimationController : MonoBehaviour
    {

        public Animator animator;
        public string idle = "idle";
        public string walkForwardAnimation = "walk_forward";
        public string walkBackwardAnimation = "walk_backwards";
        public string runForwardAnimation = "run_forward";
        public string turn90LAnimation = "turn_90_L";
        public string turn90RAnimation = "turn_90_R";
        public string trotAnimation = "trot_forward";
        public string sittostandAnimation = "sit_to_stand";
        public string standtositAnimation = "stand_to_sit";

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {   
            
            if (Input.GetKey(KeyCode.W))
            {

                animator.Play(walkForwardAnimation);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                
                animator.Play(walkBackwardAnimation);

            } else {

                animator.Play(idle);

            }

        }
    }
}
