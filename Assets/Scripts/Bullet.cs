using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 70f;
    public GameObject bulletImpactEffect;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 dir = target.position - transform.position;
            float distance = speed * Time.deltaTime;

            if(dir.magnitude <= distance)
            {
                HitTarget();
            }
            else
            {
                transform.Translate(dir.normalized * distance, Space.World);
            }
        }
    }

    public void Seek(Transform target)
    {
        this.target = target;
    }

    public void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        Destroy(gameObject);
    }
}
