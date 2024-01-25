using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem sistemaDeParticulas1;
    public ParticleSystem sistemaDeParticulas2;
    public ParticleSystem sistemaDeParticulas3;
    private float ppos = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ReproducirParticulas(sistemaDeParticulas1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ReproducirParticulas(sistemaDeParticulas2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // ReproducirParticulas(sistemaDeParticulas3);
            Vector3 pos = new Vector3(2f,ppos,2f); // the point of intersection between the particle and the enemy
            // Instantiate(prefab, pos, Quaternion.identity);
            // GameObject vfx = Instantiate(enemyHitVFX, pos, Quaternion.identity); // creating the explosion effect.
            // vfx.transform.parent = parentGameobject.transform; // this makes the new gameobjects children to my "VFX Parent" gameObject in my Hierarchy, for organizarion purposes
            sistemaDeParticulas2.transform.position = pos;
            
            
            sistemaDeParticulas2.Emit(10);


            ppos++;
        }
    }

    void ReproducirParticulas(ParticleSystem sistemaDeParticulas)
    {
        sistemaDeParticulas.Play();
    }
}
