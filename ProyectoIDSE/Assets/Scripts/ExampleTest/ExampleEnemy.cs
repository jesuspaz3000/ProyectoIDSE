using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEnemy : MonoBehaviour
{
    // public GameObject prefab;
    public ParticleSystem Particulas;
    public ParticleSystem PartickeExplosion;

    public List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
    ParticleSystem _particleSystem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnParticleCollision(GameObject other)
    {
        print("collision");
        // ParticleSystem part = other.GetComponent<ParticleSystem>(); // *** important! Making a variable to acess the particle system of the emmiting object, in this case, the lasers from my player ship.
        int numCollisionEvents = Particulas.GetCollisionEvents(this.gameObject, collisionEvents);

        foreach (ParticleCollisionEvent collisionEvent in collisionEvents) // for each collision, do the following:
        {
            Vector3 pos = collisionEvent.intersection; // the point of intersection between the particle and the enemy
            // Instantiate(prefab, pos, Quaternion.identity);
            // GameObject vfx = Instantiate(enemyHitVFX, pos, Quaternion.identity); // creating the explosion effect.
            // vfx.transform.parent = parentGameobject.transform; // this makes the new gameobjects children to my "VFX Parent" gameObject in my Hierarchy, for organizarion purposes
            PartickeExplosion.transform.position = pos;
            
            
            PartickeExplosion.Emit(10);

        }

    }

    public void doAnithing(){
        
    }

}