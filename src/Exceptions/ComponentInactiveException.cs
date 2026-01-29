using System;

namespace Firebot.Exceptions;

/// <summary>
///     Exceção lançada quando um componente existe, mas não está ativo na hierarquia.
/// </summary>
public class ComponentInactiveException : FirebotException
{
    public ComponentInactiveException(string path, string contextInfo = null, string correlationId = null)
        : base($"Component at '{path}' exists but is not active in hierarchy.", contextInfo, correlationId)
    {
        Path = path;
    }

    public ComponentInactiveException(string path, string message, string contextInfo = null,
        string correlationId = null, Exception inner = null)
        : base(message, contextInfo, correlationId, inner)
    {
        Path = path;
    }

    /// <summary>
    ///     The name of the event where the error occurred.
    /// </summary>
    public string Path { get; }
}