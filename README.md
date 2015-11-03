## StringTemplateEngine

A stand alone string template engine.

## Code Example

```cs
StringTemplate stringTemplate = new StringTemplate("hello <data>");
stringTemplate.Add("data", "world");

Console.WriteLine(stringTemplate.Render());
```
