using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 turretOffset;

    private GameObject turret;
    private Renderer rend;
    private Color startColor;
    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;

        this.rend = GetComponent<Renderer>();
        this.startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if(buildManager != null)
        {
            // Only build a turret if the node doesn't already have one and the mouse pointer isn't over a UI element.
            if(turret == null && EventSystem.current.IsPointerOverGameObject() == false)
            {
                GameObject turret = buildManager.GetTurretToBuild();
                this.turret = (GameObject)Instantiate(turret, transform.position + turretOffset, transform.rotation);
            }
            else
            {
                Debug.Log("Can't build there!");
            }
        }
    }

    void OnMouseEnter()
    {
        if(buildManager.GetTurretToBuild() != null && EventSystem.current.IsPointerOverGameObject() == false)
        {
            rend.material.color = this.hoverColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = this.startColor;
    }
}
