//
// Klak - Utilities for creative coding with Unity
//
// Copyright (C) 2016 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
using UnityEngine;
using UnityEngine.Events;

namespace Klak.Wiring
{
    [AddComponentMenu("Klak/Wiring/Output/System Property Out")]
    public class SystemPropertyOut : NodeBase
    {
        #region Editable properties

        [SerializeField]
        Material _skyboxMaterial;

        static int _last_aa_value = 0;

        #endregion

        #region Node I/O

        [Inlet]
        public float timeScale {
            set {
                if (enabled) Time.timeScale = value;
            }
        }

        [Inlet]
        public Vector3 gravity {
            set {
                if (enabled) Physics.gravity = value;
            }
        }

        [Inlet]
        public Color ambientColor {
            set {
                if (enabled) RenderSettings.ambientLight = value;
            }
        }

        [Inlet]
        public float ambientIntensity {
            set {
                if (enabled) RenderSettings.ambientIntensity = value;
            }
        }

        [Inlet]
        public float reflectionIntensity {
            set {
                if (enabled) RenderSettings.reflectionIntensity = value;
            }
        }

        [Inlet]
        public Color fogColor {
            set {
                if (enabled) RenderSettings.fogColor = value;
            }
        }

        [Inlet]
        public float fogDensity {
            set {
                if (enabled) RenderSettings.fogDensity = value;
            }
        }

        [Inlet]
        public float fogStartDistance {
            set {
                if (enabled) RenderSettings.fogStartDistance = value;
            }
        }

        [Inlet]
        public float fogEndDistance {
            set {
                if (enabled) RenderSettings.fogEndDistance = value;
            }
        }

        [Inlet]
        public void SetSkybox() 
        {
            if (enabled) RenderSettings.skybox = _skyboxMaterial;
        }

        [Inlet]
        public float antiAliasing
        {
            set
            {
                if (enabled)
                {
                    int value_i = (int)Mathf.Clamp(value, 0f, 4f) * 2;
                    if (value_i != _last_aa_value)
                    {
                        QualitySettings.antiAliasing = value_i;
                        _last_aa_value = value_i;
                    }
                }
            }
        }

        #endregion
    }
}
