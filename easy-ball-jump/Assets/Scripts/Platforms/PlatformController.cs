using UnityEngine;

namespace Platforms {
    public abstract class PlatformController : MonoBehaviour {
        public void SetRandomPosition() {
            float xPox = Random.Range(-5.5f, 5.5f);
            transform.position = new Vector3(xPox, transform.position.y, transform.position.z);
        }
    }
}