using Xunit;

namespace CircusTests.DAL.Data
{
    [CollectionDefinition(nameof(RepositoriesCollection))]
    public class RepositoriesCollection : ICollectionFixture<XmlRepositoriesFixture>
    {
    }
}