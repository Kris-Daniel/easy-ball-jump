using System;
using UnityEngine;

namespace Helpers {
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {
        static T _instance;

        public static T Instance {
            get {
                if(_instance == null)
                    Debug.LogError(typeof(T).ToString() + " is NULL");
                return _instance;
            }
        }

        void Awake() {
            _instance = this as T;
            Init();
        }

        public virtual void Init() {}
    }
}