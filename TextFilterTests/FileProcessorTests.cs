using AutoFixture;
using NUnit.Framework;
using TextFilter;

namespace TextFilterTests;

public class FileProcessorTests
{
    private Fixture _fixture;
    private FileProcessor _fileProcessor;

    private const string _expectedResultOne =
        "beginning and once she reading and use she considering own she and and picking daisies " +
        "remarkable she she all and and hurried flashed she never and burning she and large under hedge " +
        "never once considering world she and dipped herself she herself falling she she she and " +
        "wonder happen she and she she sides and filled and shelves and she and She one shelves " +
        "she passed she killing one she";
    
    private const string _expectedResultTwo = "working expressions";
    private const string _expectedResultThree = "she";

    private static IEnumerable<TestCaseData> TestCaseSourceData()
    {
        yield return new TestCaseData("InputOne.txt", _expectedResultOne);
        yield return new TestCaseData("InputTwo.txt", _expectedResultTwo);
        yield return new TestCaseData("InputThree.txt", _expectedResultThree);
    }

    [SetUp]
    public void SetUp()
    {
        _fixture = new Fixture();
        _fileProcessor = _fixture.Create<FileProcessor>();
    }

    [Test]
    [TestCaseSource(nameof(TestCaseSourceData))]
    public void FileReader_Filters_Correctly(string input, string output)
    {
        var result = _fileProcessor.FilterFile(input);
        Assert.AreEqual(output, result);
    }
}