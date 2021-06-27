using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int value;
    public enum Type { General, Recycling, Compost };
    public Type type;
}
