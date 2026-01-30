using System;

namespace Firebot.Exceptions
{
    /// <summary>
    ///     Exception thrown when a specified path is not found.
    ///     <para>Use when a file or directory path cannot be located.</para>
    ///     <para>Improves traceability and enables targeted error handling for missing paths.</para>
    /// </summary>
    public class PathNotFoundException : FirebotException
    {


        /// <summary>
        ///     Creates a PathNotFoundException with a standardized message including the path.
        /// </summary>
        /// <param name="correlationId">Unique identifier for traceability.</param>
        /// <param name="contextInfo">Additional context for debugging/logging.</param>
        /// <param name="inner">The inner exception, if any.</param>
        public PathNotFoundException(string correlationId = null, string contextInfo = null, Exception inner = null)
            : base($"Path was not found. See details for context.", contextInfo, correlationId, inner)
        {
        }

        /// <summary>
        ///     Creates a PathNotFoundException with a custom message and path.
        /// </summary>
        /// <param name="message">Custom error message.</param>
        /// <param name="correlationId">Unique identifier for traceability.</param>
        /// <param name="contextInfo">Additional context for debugging/logging.</param>
        /// <param name="inner">The inner exception, if any.</param>
        public PathNotFoundException(string path, string message, string correlationId = null, string contextInfo = null, Exception inner = null)
            : base(message, contextInfo, correlationId, inner)
        {
        }
    }
}
