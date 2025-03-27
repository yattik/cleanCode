
namespace TemplateEngine;

public class TemplateEngine
{
    private string name;
    private string value;
    private string template;
    public string Evaluate()
    {
        return "Hello Yattik";
    }

    public void setTemplate(string template)
    {
        this.template = template;
    }

    public void setVariable(string name, string value)
    {
        this.value = value;
        this.name = name;
    }
}
