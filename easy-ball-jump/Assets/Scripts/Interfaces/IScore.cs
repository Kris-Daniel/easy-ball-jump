using UnityEngine.UI;

namespace Interfaces {
    public interface IScore {
        Text text { get; set; }
        void SetScore();
    }
}