using Unity.Entities;

[System.Serializable]
public struct SpawnComponent : IComponentData
{
    public Entity Prefab;
}
