using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmo : MonoBehaviour {

    public bool showGizmos = true;
    public string icon = string.Empty;

    [Range(0f, 100f)]
    public float range = 10f;
    // Use this for initialization
    private void OnDrawGizmos() {
        if (!showGizmos) return;

        Gizmos.DrawIcon(transform.position, icon, true);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position+ transform.forward *range);
    }

    private void OnDrawGizmosSelected() {
     

    }
}
