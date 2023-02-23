﻿/*
Copyright (c) 2021 Omar Duarte
Unauthorized copying of this file, via any medium is strictly prohibited.
Writen by Omar Duarte, 2021.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#if UNITY_2019_1_OR_NEWER
using UnityEngine;

namespace PluginMaster
{
    public static partial class Shortcuts
    {
#if !PWB_3_4_OR_NEWER 
        #region TOGGLE TOOLS
        public const string PWB_TOGGLE_PIN_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Pin Tool";
         [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_PIN_SHORTCUT_ID,
             KeyCode.Alpha1, UnityEditor.ShortcutManagement.ShortcutModifiers.Shift
             | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
         private static void TogglePin() => PWBIO.ToogleTool(ToolManager.PaintTool.PIN);

        public const string PWB_TOGGLE_BRUSH_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Brush Tool";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_BRUSH_SHORTCUT_ID, KeyCode.Alpha2,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleBrush() => PWBIO.ToogleTool(ToolManager.PaintTool.BRUSH);

        public const string PWB_TOGGLE_GRAVITY_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Gravity Tool";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_GRAVITY_SHORTCUT_ID, KeyCode.Alpha3,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleGravity() => PWBIO.ToogleTool(ToolManager.PaintTool.GRAVITY);

        public const string PWB_TOGGLE_LINE_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Line Tool";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_LINE_SHORTCUT_ID, KeyCode.Alpha4,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleLine() => PWBIO.ToogleTool(ToolManager.PaintTool.LINE);

        public const string PWB_TOGGLE_SHAPE_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Shape Tool";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_SHAPE_SHORTCUT_ID, KeyCode.Alpha5,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleShape() => PWBIO.ToogleTool(ToolManager.PaintTool.SHAPE);

        public const string PWB_TOGGLE_TILING_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Tiling Tool";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_TILING_SHORTCUT_ID, KeyCode.Alpha6,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleTiling() => PWBIO.ToogleTool(ToolManager.PaintTool.TILING);

        public const string PWB_TOGGLE_REPLACER_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Replacer Tool";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_REPLACER_SHORTCUT_ID, KeyCode.Alpha7,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleReplacer() => PWBIO.ToogleTool(ToolManager.PaintTool.REPLACER);

        public const string PWB_TOGGLE_ERASER_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Eraser Tool";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_ERASER_SHORTCUT_ID, KeyCode.Alpha8,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleEraser() => PWBIO.ToogleTool(ToolManager.PaintTool.ERASER);

        public const string PWB_TOGGLE_SELECTION_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Selection Tool";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_SELECTION_SHORTCUT_ID, KeyCode.Alpha9,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleSelection() => PWBIO.ToogleTool(ToolManager.PaintTool.SELECTION);

        public const string PWB_TOGGLE_EXTRUDE_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Extrude Tool";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_EXTRUDE_SHORTCUT_ID, KeyCode.X,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleExtrude() => PWBIO.ToogleTool(ToolManager.PaintTool.EXTRUDE);

        public const string PWB_TOGGLE_MIRROR_SHORTCUT_ID = "Prefab World Builder/Tools - Toggle Mirror Tool";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_MIRROR_SHORTCUT_ID, KeyCode.M,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleMirror() => PWBIO.ToogleTool(ToolManager.PaintTool.MIRROR);
        #endregion

        #region GRID AND SNAPPING
        public const string PWB_FRAME_GRID_ORIGIN_SHORTCUT_ID
            = "Prefab World Builder/Grid - Frame Origin";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_FRAME_GRID_ORIGIN_SHORTCUT_ID, KeyCode.Q,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Action | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void FrameGridOrigin() => SnapManager.FrameGridOrigin();

        public const string PWB_TOGGLE_GRID_POSITION_HANDLE_SHORTCUT_ID
            = "Prefab World Builder/Grid - Toggle Postion Handle";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_GRID_POSITION_HANDLE_SHORTCUT_ID, KeyCode.W,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Action | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleGridPositionHandle() => SnapManager.ToggleGridPositionHandle();

        public const string PWB_TOGGLE_GRID_ROTATION_HANDLE_SHORTCUT_ID
            = "Prefab World Builder/Grid - Toggle Rotation Handle";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_GRID_ROTATION_HANDLE_SHORTCUT_ID, KeyCode.E,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Action | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleGridRotationHandle() => SnapManager.ToggleGridRotationHandle();

        public const string PWB_TOGGLE_GRID_SCALE_HANDLE_SHORTCUT_ID
            = "Prefab World Builder/Grid - Toggle Spacing Handle";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_TOGGLE_GRID_SCALE_HANDLE_SHORTCUT_ID, KeyCode.R,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Action | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void ToggleGridScaleHandle() => SnapManager.ToggleGridScaleHandle();

        #endregion

        #region PALETTE

        public const string PWB_NEW_MULTIBRUSH_FROM_SELECTION_SHORTCUT_ID
            = "Prefab World Builder/Palette - New MultiBrush From Selection";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_NEW_MULTIBRUSH_FROM_SELECTION_SHORTCUT_ID)]
        private static void NewMultiBrushFromSelection()
        {
            if (PrefabPalette.instance == null) PrefabPalette.ShowWindow();
            PrefabPalette.instance.CreateBrushFromSelection();
        }

        public const string PWB_NEW_BRUSH_FROM_EACH_PREFAB_SELECTED_SHORTCUT_ID
            = "Prefab World Builder/Palette - New Brush From Each Prefab Selected";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_NEW_BRUSH_FROM_EACH_PREFAB_SELECTED_SHORTCUT_ID)]
        private static void NewBushFromEachPrefabSelected()
        {
            if (PrefabPalette.instance == null) PrefabPalette.ShowWindow();
            PrefabPalette.instance.CreateBushFromEachPrefabSelected();
        }

        public const string PWB_FILTER_BRUSH_BY_SELECTION_SHORTCUT_ID = "Prefab World Builder/Palette - Filter by selection";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_FILTER_BRUSH_BY_SELECTION_SHORTCUT_ID)]
        private static void FilterBySelection()
        {
            if (PrefabPalette.instance == null) PrefabPalette.ShowWindow();
            if (PrefabPalette.instance.FilterBySelection() == 1) PrefabPalette.instance.SelectFirstBrush();
        }
        #endregion
#endif
        #region WINDOWS
        public const string PWB_CLOSE_ALL_WINDOWS_ID = "Prefab World Builder/Close All Windows";
        [UnityEditor.ShortcutManagement.Shortcut(PWB_CLOSE_ALL_WINDOWS_ID, KeyCode.End,
            UnityEditor.ShortcutManagement.ShortcutModifiers.Shift | UnityEditor.ShortcutManagement.ShortcutModifiers.Alt)]
        private static void PWBCloseAllWindows()
        {
            ToolManager.DeselectTool();
            PWBIO.CloseAllWindows();
        }
        #endregion

    }
}
#endif