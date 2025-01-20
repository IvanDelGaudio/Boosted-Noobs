using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    public class Item : MonoBehaviour
    {
        public string name;

        public Item(string itemName)
        {
            name = itemName;
            
        }
    }
}
