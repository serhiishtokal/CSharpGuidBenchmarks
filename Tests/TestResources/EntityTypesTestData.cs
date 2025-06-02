namespace Tests.TestResources;

public class EntityTypesTestData : TheoryData<Type>
{
    public EntityTypesTestData() : base()
    {
        AddRange(EntityConstants.EntityTypes.ToArray());
    }
}