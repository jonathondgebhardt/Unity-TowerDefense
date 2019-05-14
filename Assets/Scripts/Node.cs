using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 turretOffset;

    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    void Start()
    {
        this.rend = GetComponent<Renderer>();
        this.startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build there!");
        }
        else
        {
            GameObject turret = BuildManager.instance.GetTurretToBuild();
            this.turret = (GameObject)Instantiate(turret, transform.position + turretOffset, transform.rotation);
        }
    }

    void OnMouseEnter()
    {
        rend.material.color = this.hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = this.startColor;
    }
}
