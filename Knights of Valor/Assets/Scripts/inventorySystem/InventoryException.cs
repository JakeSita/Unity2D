using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace inventorySystem
{
    public enum InventoryOperation
    {
        Add,
        Remove
    }

    public class InventoryException : Exception
    {

        public InventoryOperation Operation { get; }
        public InventoryException(InventoryOperation operation, String msg) : base($"{operation} error: {msg}")
        {
            Operation = operation;

        }

    }
}
