using System.Text.RegularExpressions;

namespace SignalR_Errors
{
    public class ErrorLists : Exception
    {
        public IReadOnlyList<string> Errors { get; }
        
        public ErrorLists(IEnumerable<string> errors)
            : base("Erros de validação encontrados")
        {
            Errors = errors?.ToList() ?? new List<string>();
        }
        
        public ErrorLists(string message, IEnumerable<string> errors)
            : base(message)
        {
            Errors = errors?.ToList() ?? new List<string>();
        }

        public override string ToString()
        {
            return $"{Message}: {string.Join(", ", Errors)}";
        }
    }
}