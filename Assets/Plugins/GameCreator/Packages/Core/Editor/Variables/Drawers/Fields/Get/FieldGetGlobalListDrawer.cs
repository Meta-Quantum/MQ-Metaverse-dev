using GameCreator.Editor.Common;
using GameCreator.Runtime.Variables;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace GameCreator.Editor.Variables
{
    [CustomPropertyDrawer(typeof(FieldGetGlobalList))]
    public class FieldGetGlobalListDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement();
            
            SerializedProperty propertyVariable = property.FindPropertyRelative("m_Variable");
            SerializedProperty propertySelect = property.FindPropertyRelative("m_Select");

            PropertyTool fieldVariable = new PropertyTool(propertyVariable);
            PickFieldElement fieldSelect = new PickFieldElement(propertySelect, " ");
            
            root.Add(fieldVariable);
            root.Add(fieldSelect);

            return root;
        }
    }
}