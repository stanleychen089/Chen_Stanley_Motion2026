using UnityEngine;
using UnityEngine.InputSystem;

public class CannonballController : MonoBehaviour
{
    public float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        //After lifespan seconds, this object will be destroyed
        Destroy(gameObject, lifespan);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //On collision enter, the code will check if the collided object is a cannonball
        //All cannonballs will uniquely have the cannonball controller script, thus if it has it, its a cannonballl
        //Get the collider's gameObject component if the object is indeed a cannonball 
        CannonballController otherCannonball = collision.gameObject.GetComponent<CannonballController>();

        //both cannonballs are destroyed if otherCannonball obtains something, which only happens if the the collided object is a cannonball
        if(otherCannonball != null)
        {
            Destroy(otherCannonball.gameObject);
            Destroy(gameObject);
        }
    }

}
