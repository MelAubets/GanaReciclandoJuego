using UnityEngine;
using UnityEngine.Tilemaps;

public enum Waste
{
    GLASS,
    PAPER,
    PLASTIC

}

[System.Serializable]
public struct WasteData
{
    public Tile tile;
    public Waste waste;
}
