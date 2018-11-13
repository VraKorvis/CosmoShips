using Entitas;
using Entitas.Unity;
using UnityEngine;

public class ViewController : MonoBehaviour, IViewController {

    public virtual Vector3 position {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }

    public virtual void Link(Entity entity, IContext icontexts) {
        gameObject.Link(entity, icontexts);
    }

    public virtual void Show(bool animated) {
        gameObject.SetActive(true);
    }

    public virtual void Hide(bool animated) {
        gameObject.SetActive(false);
    }

    public virtual void Hide(bool animated, Vector3 pos) {
        gameObject.SetActive(false);
    }

    public virtual void Reset() {
        gameObject.Unlink();
    }
}
