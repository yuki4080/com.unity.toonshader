using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityEditor.Rendering.HDRP.Toon
{

    internal class OptimizeForHDRLightIntensityWindow : EditorWindow
    {
        Material m_material;
        HDRPToonGUI m_gui;
        internal static void OpenWindow(HDRPToonGUI gui, Material material)
        {
            var window = GetWindow<OptimizeForHDRLightIntensityWindow>();
            window.m_material = material;
            window.m_gui = gui;
        }

        private void OnGUI()
        {
            if ( m_gui == null || m_material == null)
            {
                Close();
            }
            m_gui.GUI_OptimizeForHDRLightIntensity(m_material);
        }
    }
}
