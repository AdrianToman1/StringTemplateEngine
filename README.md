## StringTemplateEngine

A stand alone string template engine.

## Code Example

```cs
StringTemplate stringTemplate = new StringTemplate("hello <data>");
stringTemplate.Add("data", "world");

Console.WriteLine(stringTemplate.Render());
```

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
