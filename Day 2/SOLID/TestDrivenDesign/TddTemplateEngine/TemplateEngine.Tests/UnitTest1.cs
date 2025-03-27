namespace TemplateEngine.Tests;

public class TemplateEngineTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldEvaluateForSingleVersion()
    {
        //Arrange
        TemplateEngine templateEngine = new TemplateEngine();
        templateEngine.setTemplate("Hello {name}");
        templateEngine.setVariable("name", "Yattik");
        //ACT
        String result = templateEngine.Evaluate();

        Assert.That("Hello Yattik",Is.EqualTo(result));
        //Assert
    }
    [Test]
    public void ShouldWorkForAnotherSingleVariable()
    {
        //Arrange
        TemplateEngine templateEngine = new TemplateEngine();
        templateEngine.setTemplate("Hello {name}");
        templateEngine.setVariable("name", "Anju");
        //ACT
        String result = templateEngine.Evaluate();

        Assert.That("Hello Anju", Is.EqualTo(result));
        //Assert
    }
}