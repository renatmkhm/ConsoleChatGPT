namespace ConsoleChatGPT;

public class Settings
{
    public string Key { get; set; } = string.Empty;

    public string? Endpoint { get; set; }

    public string? OrgId { get; set; }

    public string Model { get; set; } = "chat";

    public string SystemPrompt { get; set; }
        = """
        You are a friendly assistant named ConsoleChatGPT. 
        You are an expert in the .NET runtime and C# and F# programming languages.
        Response using programming slang.
        """;

    public int MaxTokens { get; set; } = 1500;

    public float Temperature { get; set; } = 0.4f;

    public float TopP { get; set; }

    public float FrequencyPenalty { get; set; }

    public float PresencePenalty { get; set; }
}
