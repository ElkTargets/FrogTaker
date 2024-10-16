using System;
using System.Reflection;
using Frogs;
using UnityEngine;

namespace Proto.Script
{
    public class InventorySlot : MonoBehaviour
    {
        public FrogData frogData;
        public bool enableSlot;
        public GameObject slotObject;
        public GameObject infoPanel;

        private void FixedUpdate()
        {
            if (!slotObject.activeSelf)
            {
                Type type = typeof(FrogDexUnlocks);
                FieldInfo field = type.GetField(frogData.name, BindingFlags.Public | BindingFlags.Static);
                if (field != null & field.FieldType == typeof(bool))
                {
                    bool flagValue = (bool)field.GetValue(null);

                    if (flagValue)
                    {
                        enableSlot = true;
                    }
                }
            }
            if (enableSlot && !slotObject.activeSelf)
            {
                slotObject.SetActive(true);
            }
        }

        public void ActiveInfoPanel()
        {
            infoPanel.SetActive(true);
            infoPanel.GetComponent<FrogInfo>().DisplayPanel(frogData);
        }
    }
}
