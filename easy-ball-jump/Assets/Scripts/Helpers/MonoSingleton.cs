using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Helpers {
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {
        static T _instance;

        [CanBeNull]
        public static T Instance {
            get {
                if (_instance == null) {
                    Debug.Log(typeof(T).ToString() + " is NULL");
                    return null;
                }
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